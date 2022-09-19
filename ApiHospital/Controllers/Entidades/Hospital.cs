using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApiHospital.Controllers.Entidades
{
    public class Hospital
    {
        [Key]
        public int Id { get; set; }
        public int IdHospital { get; set; }
        public String NombreHospital { get; set; }
        public Paciente Paciente { get; set; }
    }
}
