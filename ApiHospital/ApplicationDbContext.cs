using Microsoft.EntityFrameworkCore;
using ApiHospital.Entidades;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using ApiHospital.Controllers.Entidades;

namespace ApiHospital
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {

        }
        //para el AddEntityFrameworkStores
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<HospitalPaciente>().HasKey(aux => new { aux.HospitalId, aux.PacienteId });
        }
        //Cuando se cree la bd se creara una tabla con los datos de:
        public DbSet<Hospital> Hospitales { get; set; }
        public DbSet<Paciente> Pacientes { get; set; }
        public DbSet<Enfermedad> Enfermedades { get; set; }

        public DbSet<HospitalPaciente> HospitalPacientes { get; set; }
    }
}
