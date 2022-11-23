using ApiHospital.Validaciones;
using System.ComponentModel.DataAnnotations;

namespace ApiHospital.DTOs
{
    public class PacientePatchDTO
    {
        [Required(ErrorMessage = "El Nombre es obligatorio")]
        [StringLength(60, MinimumLength = 10, ErrorMessage = "Introduce un nombre valido")]
        [PrimeraLetraMayuscula]
        public string Nombre { get; set; }

        public DateTime FechaCreacion { get; set; }
    }
}
