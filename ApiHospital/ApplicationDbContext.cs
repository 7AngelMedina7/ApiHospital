using ApiHospital.Controllers.Entidades;
using ApiHospital.Entidades;
using Microsoft.EntityFrameworkCore;

namespace ApiHospital
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {

        }
        //Cuando se cree la bd se creara una tabla con los datos de:
        public DbSet<Hospital> Hospitales { get; set; }
        public DbSet<Paciente> Pacientes { get; set; }
        public DbSet<Enfermedad> Enfermedads { get; set; }

        public DbSet<HospitalPaciente> HospitalPacientes { get; set; }
    }
}
