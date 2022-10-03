using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BussinesLogicLibrary.ViewModels
{
    public partial class PersonaInputViewModel
    {
        
        [Required]
        public int? IdDocumento { get; set; }

        [Required]
        public int? IdGenero { get; set; }

        [Required]
        public string? Nombre { get; set; }

        [Required]
        public string? Apellido { get; set; }

        [Required]
        public long? NumeroDocumento { get; set; }

        [Required]
        public DateTime? FechaNacimiento { get; set; }
        
    }
}
