using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApiHospital.Controllers.Entidades
{
    public class Paciente
    {
        [ForeignKey("Id")]
        [Key]
        public int IdPaciente { get; set; }
        public string Nombre { get; set; }
        public int Edad { get; set; }   

    }
}
