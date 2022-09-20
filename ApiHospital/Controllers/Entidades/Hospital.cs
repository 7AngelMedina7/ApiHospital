using System.ComponentModel.DataAnnotations;

namespace ApiHospital.Controllers.Entidades
{
    public class Hospital
    {
        [Key] 
        public int IdHospital { get; set; }
        public String NombreHospital { get; set; }
        public List<Paciente> Pacientes { get; set; }
    }
}
