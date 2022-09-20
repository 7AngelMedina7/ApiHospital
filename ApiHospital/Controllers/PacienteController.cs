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
            if (paciente.Nombre == "string")
            {
                return BadRequest("EL nombre del Hospital no debe quedar vacio");
            }
            else if (paciente.HospitalId == 0)
            {
                return BadRequest("Debe introducir HospitalId");
            }
            else if (String.IsNullOrEmpty(paciente.Nombre))
            {
                return BadRequest("Debe Introducir el Nombre del paciente");
            }
            else if (paciente.Edad == 0)
            {
                return BadRequest("Debe introducir el parametro Edad");
            }
            else if (paciente.peso == 0)
            {
                return BadRequest("Debe introducir el parametro Peso");
            }
            else if (paciente.estatura == 0)
            {
                return BadRequest("Debe introducir el parametro Estatura");
            }
            else if (paciente.IdPaciente == 0)
            {
                return BadRequest("Debe introducir el Id del paciente");
            }
            else if (paciente.IdPaciente != id)
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
