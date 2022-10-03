using System;
using System.Collections.Generic;

namespace BussinesLogicLibrary.ViewModels
{
    public partial class PersonaViewModel
    {
        public int Id { get; set; }
        public int? IdDocumento { get; set; }
        public int? IdGenero { get; set; }
        public string? Nombre { get; set; }
        public string? Apellido { get; set; }
        public long? NumeroDocumento { get; set; }
        public DateTime? FechaNacimiento { get; set; }
        public DateTime? FechaCreacion { get; set; }
        public DateTime? FechaActualizacion { get; set; }

        public virtual DocumentoViewModel? Documento { get; set; }
        public virtual GeneroViewModel? Genero { get; set; }

        public string? Clasificacion { get; set; }
    }
}
