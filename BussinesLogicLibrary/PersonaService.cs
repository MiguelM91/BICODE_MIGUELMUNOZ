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



    }
}