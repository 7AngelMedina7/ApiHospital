using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApiHospital.Controllers.Entidades
{
    public class Paciente
    {
        [Key]
        public int Id { get; set; }
        public int IdPaciente { get; set; }
        public string Names { get; set; }
        public int Edad { get; set; }

    }
}
