using ApiHospital.Controllers.Entidades;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ApiHospital.Controllers
{
    [ApiController]
    [Route("/Paciente")]
    public class PacienteController: ControllerBase
    {
        public PacienteController(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public ApplicationDbContext dbContext { get; }
        [HttpGet]
        public async Task<ActionResult<List<Paciente>>> Get(int id)
        {
            return await dbContext.Pacientes.ToListAsync();
        }
        [HttpPost]
        public async Task<ActionResult> Post(Paciente paciente)
        {
            dbContext.Add(paciente);
            await dbContext.SaveChangesAsync();
            return Ok();
        }
        [HttpPut("{id:int}")]
        public async Task<ActionResult> Put(Paciente paciente, int id)
        {
            if (paciente.IdPaciente != id)
            {
                return BadRequest("El id del no coincide con el de la url.");
            }
            dbContext.Update(paciente);
            await dbContext.SaveChangesAsync();
            return Ok();
        }
        [HttpDelete("{id:int}")]
        public async Task<ActionResult> Delete(int id)
        {
            var pacientelDelete = await dbContext.Pacientes.FindAsync(id);
            dbContext.Pacientes.Remove(pacientelDelete);
            await dbContext.SaveChangesAsync();
            return Ok();
        }
    }
}
