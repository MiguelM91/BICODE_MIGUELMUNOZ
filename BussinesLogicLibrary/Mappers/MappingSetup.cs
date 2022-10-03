using AutoMapper;
using BussinesLogicLibrary.ViewModels;
using DataAccessLibrary.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinesLogicLibrary.Mappers
{
    public class MappingSetup: Profile
    {
        public MappingSetup()
        {
            ConfigureMappingFromEntitiesToViewModels();
        }

        private void ConfigureMappingFromEntitiesToViewModels()
        {
            CreateMap<Persona, PersonaViewModel>()
                .ForMember(d => d.Documento, s => s.MapFrom(src => src.IdDocumentoNavigation))
                .ForMember(d => d.Genero, s => s.MapFrom(src => src.IdGeneroNavigation))
                .ForMember(d => d.Clasificacion, s => s.MapFrom((x,d) => {               



                    if (x.FechaNacimiento != null) {
                        var age = 0;

                        age = DateTime.Now.Subtract(x.FechaNacimiento.Value).Days;
                        age = age / 365;

                        if (age <= 14) {
                            return "Niño";
                        }

                        else if (age >= 15 && age <= 20)
                        {
                            return "Adolescente";
                        }

                        else if (age >= 21 && age <= 60)
                        {
                            return "Mayor de edad";
                        }

                        else
                        {
                            return "Tercera edad";
                        }

                    }
                    
                    return "NA";
                    
                }  ));
            CreateMap<Documento, DocumentoViewModel>();
            CreateMap<Genero, GeneroViewModel>();

        }
    }
}
