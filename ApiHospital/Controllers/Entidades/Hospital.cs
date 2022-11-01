using System.ComponentModel.DataAnnotations;
using ApiHospital.Validaciones;

namespace ApiHospital.Controllers.Entidades
{
    public class Hospital
    {
        [Key]

        public int IdHospital { get; set; }
        [Required(ErrorMessage ="El Nombre del hospital es obligatorio")]
        [StringLength(70, MinimumLength = 5, ErrorMessage = "Introduce un nombre valido")]
        [PrimeraLetraMayuscula]
        public string NombreHospital { get; set; }
        public List<Paciente> Pacientes { get; set; }
    }
}
