using ApiHospital.Controllers.Entidades;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ApiHospital.Controllers
{
    [ApiController]
    [Route("/Hospital")]
    public class HospitalController : ControllerBase
    {
        public HospitalController(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public ApplicationDbContext dbContext { get; }
        [HttpGet]
        public async Task<ActionResult<List<Hospital>>> Get(int id)
        {
            return await dbContext.Hospitales.ToListAsync();
        }
        [HttpPost]
        public async Task<ActionResult> Post(Hospital hospital)
        {
            dbContext.Add(hospital);
            await dbContext.SaveChangesAsync();
            return Ok();
        }
        [HttpPut("{id:int}")]
        public async Task<ActionResult> Put(Hospital hospital, int id)
        {
            if (hospital.Id != id)
            {
                return BadRequest("El id del no coincide con el de la url.");
            }
            dbContext.Update(hospital);
            await dbContext.SaveChangesAsync();
            return Ok();
        }
        [HttpDelete("{id:int}")]
        public async Task<ActionResult> Delete(int id)
        {
            var hospitalDelete = await dbContext.Hospitales.FindAsync(id);
            dbContext.Hospitales.Remove(hospitalDelete);
            await dbContext.SaveChangesAsync();
            return Ok();
        }
    }
}