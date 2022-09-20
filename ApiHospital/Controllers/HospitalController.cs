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
            if (hospital.NombreHospital=="string"|| String.IsNullOrEmpty(hospital.NombreHospital))
            {
                return BadRequest("El Nombre del Hospital no debe estar vacio");
            }
            dbContext.Add(hospital);
            await dbContext.SaveChangesAsync();
            return Ok();
        }
        [HttpPut("{id:int}")]
        public async Task<ActionResult> Put(Hospital hospital, int id)
        {
            //Verificar si los datos puestos son nulos o vacios
            if (String.IsNullOrEmpty(hospital.NombreHospital))
            {
                if (hospital.NombreHospital == "string")
                {
                    return BadRequest("EL nombre del Hospital no debe quedar vacio");
                }

                return BadRequest("Debe introducir todos los datos");
            }
            if (hospital.IdHospital != id)
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