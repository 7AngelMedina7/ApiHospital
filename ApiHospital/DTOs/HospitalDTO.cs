using ApiHospital.Validaciones;
using System.ComponentModel.DataAnnotations;

namespace ApiHospital.DTOs
{
    public class HospitalDTO
    {
        [Required(ErrorMessage = "El Nombre del hospital es obligatorio")]
        [StringLength(70, MinimumLength = 5, ErrorMessage = "Introduce un nombre valido")]
        [PrimeraLetraMayuscula]

        public string NombreHospital { get; set; }
    }
}
