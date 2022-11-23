using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ApiHospital.Entidades;
using ApiHospital.Validaciones;
using Microsoft.AspNetCore.Authorization;

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
        public List<HospitalPaciente> HospitalPaciente { get; set; }




        //Se pueden añadir las validaciones dentro de las entidades.
    }
}
