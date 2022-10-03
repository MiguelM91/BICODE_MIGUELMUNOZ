using AutoMapper;
using BussinesLogicLibrary.Exceptions;
using BussinesLogicLibrary.ViewModels;
using DataAccessLibrary;
using DataAccessLibrary.Entities;
using Microsoft.EntityFrameworkCore;

namespace BussinesLogicLibrary
{
    public class PersonaService: IPersonaService
    {

        private readonly BI_TESTGENContext _context;

        private readonly IMapper _mapper;
        public PersonaService(BI_TESTGENContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public List<PersonaViewModel> GetPersonas()
        {

            var personas = _context.Personas
                .Include("IdDocumentoNavigation")
                .Include("IdGeneroNavigation")
                .ToList();

            var result = _mapper.Map<List<Persona>, List<PersonaViewModel>>(personas);

            return result;
        }


        public PersonaViewModel GetPersona(int id)
        {

            var persona = _context.Personas
                .Include("IdDocumentoNavigation")
                .Include("IdGeneroNavigation")
                .SingleOrDefault(p => p.Id == id);

            if (persona == null) {
                throw new ResourceNotFoundException();
            }
                

            var result = _mapper.Map<Persona, PersonaViewModel>(persona);

            return result;
        }

        public PersonaViewModel CreatePersona(PersonaInputViewModel personaInput) {

            var personaEntity = _mapper.Map<PersonaInputViewModel, Persona>(personaInput);
            personaEntity.FechaCreacion = DateTime.Now;
            personaEntity.FechaActualizacion = DateTime.Now;

            _context.Personas.Add(personaEntity);
            _context.SaveChanges();

            var result = _mapper.Map<Persona, PersonaViewModel>(personaEntity);

            return result;


        }

        public PersonaViewModel UpdatePersona(PersonaInputViewModel personaInput, int id)
        {

            var persona = _context.Personas
                .SingleOrDefault(p => p.Id == id);

            if (persona == null)
            {
                throw new ResourceNotFoundException();
            }

            persona.IdDocumento = personaInput.IdDocumento;
            persona.IdGenero = personaInput.IdGenero;
            persona.NumeroDocumento = personaInput.NumeroDocumento;
            persona.FechaNacimiento = personaInput.FechaNacimiento;
            persona.Nombre = personaInput.Nombre;
            persona.Apellido = personaInput.Apellido;        
            persona.FechaActualizacion = DateTime.Now;

      
            _context.SaveChanges();

            var result = _mapper.Map<Persona, PersonaViewModel>(persona);

            return result;


        }

        public void DeletePersona(int id)
        {

            var persona = _context.Personas                
                .SingleOrDefault(p => p.Id == id);

            if (persona == null)
            {
                throw new ResourceNotFoundException();
            }

            _context.Personas.Remove(persona);
            _context.SaveChanges();

        }



    }
}