using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApiHospital.Controllers.Entidades
{
    public class Paciente
    {
        [Key]
        public int IdPaciente { get; set; }
        public int HospitalId { get; set; } 
        public string Nombre { get; set; }
        public int Edad { get; set; }
        public decimal peso { get; set; }
        public decimal estatura { get; set; }

    }
}
