using ApiHospital.Controllers.Entidades;

namespace ApiHospital.Entidades
{
    public class HospitalPaciente
    {
        //Relacion de muchos a muchos
        public int HospitalId { get; set; }
        public int PacienteId { get; set; }
        public Hospital Hospital { get; set; }
        public Paciente paciente { get; set; }
    }
}
