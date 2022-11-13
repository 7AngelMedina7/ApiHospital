using ApiHospital.Controllers.Entidades;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;


namespace ApiHospital.Controllers
{
    [ApiController]
    [Route("/Hospital")]
    public class HospitalController : ControllerBase
    {
        private readonly ApplicationDbContext dbContext;
        private readonly IService service;
        private readonly ServiceTransient serviceTransient;
        private readonly ServiceScoped serviceScoped;
        private readonly ServiceSingleton serviceSingleton;
        private readonly ILogger<AlumnosController> logger;
        private readonly IWebHostEnvironment env;
        private readonly string nuevosRegistros = "nuevosRegistros.txt";
        private readonly string registrosConsultados = "registrosConsultados.txt";

        public HospitalController(ApplicationDbContext context, IService service,
            ServiceTransient serviceTransient, ServiceScoped serviceScoped,
            ServiceSingleton serviceSingleton, ILogger<AlumnosController> logger,
            IWebHostEnvironment env)
        {
            this.dbContext = context;
            this.service = service;
            this.serviceTransient = serviceTransient;
            this.serviceScoped = serviceScoped;
            this.serviceSingleton = serviceSingleton;
            this.logger = logger;
            this.env = env;
        }
        [HttpGet("GUID")]
        [ResponseCache(Duration = 10)]
        [ServiceFilter(typeof(FiltroDeAccion))]
        public ActionResult ObtenerGuid()
        {
            throw new NotImplementedException();
            logger.LogInformation("Durante la ejecucion");
            return Ok(new
            {
                AlumnosControllerTransient = serviceTransient.guid,
                ServiceA_Transient = service.GetTransient(),
                AlumnosControllerScoped = serviceScoped.guid,
                ServiceA_Scoped = service.GetScoped(),
                AlumnosControllerSingleton = serviceSingleton.guid,
                ServiceA_Singleton = service.GetSingleton()
            });
        }

        public ApplicationDbContext dbContext { get; }
        [HttpGet("{id:int}")]
        public async Task<ActionResult<Hospital>> GetById(int id)
        {
            var idAux= await dbContext.Hospitales.Include(a => a.Pacientes).FirstOrDefaultAsync(a => a.IdHospital == id);
            if (idAux == null)
            {
                return NotFound();
            }
            return Ok(idAux);
        }
        [HttpGet("{nombreHospital}")]
        public async Task<ActionResult<Hospital>> Get(string nombreHospital)
        {
            var nombreAux= await dbContext.Hospitales.Include(a => a.Pacientes).FirstOrDefaultAsync(a => a.NombreHospital.Contains(nombreHospital));
            if (nombreAux == null)
            {
                return NotFound();
            }
            return Ok(nombreAux);
        }
        [HttpGet("{id:int}/{nombreHospital?}")]
        public async Task<ActionResult<Hospital>> Get(int id, string nombreHospital)
        {
            var aux = await dbContext.Hospitales.Include(a => a.Pacientes).FirstOrDefaultAsync(a => a.IdHospital==id || a.NombreHospital.Contains(nombreHospital));
            if (aux == null)
            {
                return NotFound();
            }
            return Ok(aux);
        }
        [HttpGet]
        public async Task<ActionResult<List<Hospital>>> Get()
        {

            return await dbContext.Hospitales.Include(a=> a.Pacientes).ToListAsync();
        }
        [HttpPost] 
        public async Task<ActionResult> Post(Hospital hospital)
        {
            var existeNombre = await dbContext.Hospitales.AnyAsync(a => a.NombreHospital == hospital.NombreHospital);
            if (existeNombre)
            {
                return BadRequest("Ya existe un hospital con el nombre proporcionado")
            }
            dbContext.Add(hospital);
            await dbContext.SaveChangesAsync();
            return Ok();
        }
        [HttpPut("{id:int}")]
        public async Task<ActionResult> Put(Hospital hospital, int id)
        {
           
           
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