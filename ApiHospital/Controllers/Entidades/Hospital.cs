using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace ApiHospital.Controllers.Entidades
{
    public class Hospital
    {
        [Key]

        public int IdHospital { get; set; }
        [Required(ErrorMessage ="El Nombre del hospital es obligatorio")]

        public string NombreHospital { get; set; }

        //[AllowNull]

        public List<Paciente> Pacientes { get; set; }
    }
}
