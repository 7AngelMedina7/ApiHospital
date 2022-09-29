using System.ComponentModel.DataAnnotations;

namespace ApiHospital.Controllers.Entidades
{
    public class Hospital
    {
        [Key]

        public int IdHospital { get; set; }
        [Required(ErrorMessage ="El Nombre del hospital es obligatorio")]
        [StringLength(70, MinimumLength = 5, ErrorMessage = "Introduce un nombre valido")]
        public string NombreHospital { get; set; }
        public List<Paciente> Pacientes { get; set; }
    }
}
