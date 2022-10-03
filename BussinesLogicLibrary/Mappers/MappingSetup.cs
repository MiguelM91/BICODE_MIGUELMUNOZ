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
                .ForMember(d => d.Documento, s => s.MapFrom( src => src.IdDocumentoNavigation))
                .ForMember(d => d.Genero, s => s.MapFrom(src => src.IdGeneroNavigation));
            CreateMap<Documento, DocumentoViewModel>();
            CreateMap<Genero, GeneroViewModel>();

        }
    }
}
