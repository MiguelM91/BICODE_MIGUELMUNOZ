using BussinesLogicLibrary.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinesLogicLibrary
{

    public interface IPersonaService
    {
        List<PersonaViewModel> GetPersonas();
        PersonaViewModel GetPersona(int id);

        PersonaViewModel CreatePersona(PersonaInputViewModel personaInput);

        PersonaViewModel UpdatePersona(PersonaInputViewModel personaInput, int id);

        void DeletePersona(int id);
    }
}
