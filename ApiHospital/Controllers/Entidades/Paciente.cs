using ApiHospital.Entidades;
using ApiHospital.Validaciones;
using Microsoft.AspNetCore.Authorization;
using System.ComponentModel.DataAnnotations;

namespace ApiHospital.Controllers.Entidades
{
    public class Paciente
    {
        public int IdPaciente { get; set; }
        [Required(ErrorMessage ="El Id del Paciente es obligatorio")]
        public int HospitalId { get; set; }

        [Required(ErrorMessage ="El Nombre es obligatorio")]
        [StringLength(60,MinimumLength =10,ErrorMessage="Introduce un nombre valido")]
        [PrimeraLetraMayuscula]
        public string Nombre { get; set; }

        public List<Paciente> Pacientes { get; set; }
        public List<HospitalPaciente> HospitalPaciente { get; set; }

        //[Required(ErrorMessage ="La edad es obligatoria")]
        //[Range(1,100,ErrorMessage ="Introduce una edad valida")]
        //public int Edad { get; set; }

        //[Required(ErrorMessage ="El peso es Obligatorio")]
        //public decimal peso { get; set; }
        
        //[Required(ErrorMessage ="La estatura es Obligatoria")]
        //public decimal estatura { get; set; }

    }
}
