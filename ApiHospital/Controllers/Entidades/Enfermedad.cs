using ApiHospital.Controllers.Entidades;
using Microsoft.AspNetCore.Identity;

namespace ApiHospital.Entidades
{
    public class Enfermedad
    {
        public int Id { get; set; }
        public string Gravedad { get; set; }

        public int EnfermedadId { get; set; }

        public Paciente Paciente { get; set; }

        public string UsuarioId { get; set; }

        public IdentityUser Usuario { get; set; }
    }
}
