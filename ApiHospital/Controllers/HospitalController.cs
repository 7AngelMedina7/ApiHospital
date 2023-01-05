using ApiHospital.Controllers.Entidades;
using ApiHospital.Filtros;
using ApiHospital.Services;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using RouteAttribute = Microsoft.AspNetCore.Mvc.RouteAttribute;
using ApiHospital.DTOs;
using Microsoft.AspNetCore.Authentication.JwtBearer;

namespace ApiHospital.Controllers
{
    [ApiController]
    [Route("/Hospital")]
    //[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Policy = "EsAdmin")]
    [AllowAnonymous]
    public class HospitalController : ControllerBase
    {
        private readonly ApplicationDbContext dbContext;
        private readonly IMapper mapper;

        public HospitalController(ApplicationDbContext context, IMapper mapper)
        {
            this.dbContext = context;
            this.mapper = mapper;
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task <ActionResult<List<GetHospitalDTO>>>Get()
        {
            var hospitales = await dbContext.Hospitales.ToListAsync();
            return mapper.Map<List<GetHospitalDTO>>(hospitales);
        }

        [HttpGet("{id:int}", Name ="obtenerHospital")]
        public async Task<ActionResult<HospitalDTOConPacientes>> Get(int id)
        {
            var hospitalAux= await dbContext.Hospitales
                .Include(hospitalDB => hospitalDB.HospitalPaciente) //Trae la info de la relacion de las clases
                .ThenInclude(hospitalPacienteDB => hospitalPacienteDB.PacienteId) //obtener el objeto de clase que se consulta
                .FirstOrDefaultAsync(hospitalDB => hospitalDB.IdHospital==id);//El primero


            if (hospitalAux == null)
            {
                return NotFound();
            }
            return Ok(hospitalAux);
        }
        [HttpGet("{nombre}")]
        public async Task<ActionResult<List<GetHospitalDTO>>> Get([FromRoute] string nombreHospital)
        {
            var hospitalesAux = await dbContext.Hospitales.Where(hospitalDB => hospitalDB.NombreHospital.Contains(nombreHospital)).ToListAsync();
            return mapper.Map<List<GetHospitalDTO>>(hospitalesAux);
        }

        [HttpPost] 
        public async Task<ActionResult> Post([FromBody] HospitalDTO hospitalDTO)
        {
            var existeNombre = await dbContext.Hospitales.AnyAsync(a => a.NombreHospital == hospitalDTO.NombreHospital);
            if (existeNombre)
            {
                return BadRequest($"Ya existe un hospital con el nombre {hospitalDTO.NombreHospital}");
            }
           
            
            var hospitalAux = mapper.Map<Hospital>(hospitalDTO);
            dbContext.Add(hospitalAux);
            await dbContext.SaveChangesAsync();
            return Ok();
        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult> Put(HospitalDTO hospitalCreacionDTO, int id)
        {
            var existe = await dbContext.Hospitales.AnyAsync(a => a.IdHospital == id);
           
            if (!existe)
            {
                return NotFound();
            }
            var hospitalAux = mapper.Map<Hospital>(hospitalCreacionDTO);
            hospitalAux.IdHospital = id;
            dbContext.Update(hospitalAux);
            await dbContext.SaveChangesAsync();
            return Ok();
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult> Delete(int id)
        {
            var existe = await dbContext.Hospitales.AnyAsync(a => a.IdHospital == id);
            if (!existe)
            {
                return NotFound("El recurso no fue encontrado");
            }
            dbContext.Hospitales.Remove(new Hospital(){
                IdHospital = id
            });
            await dbContext.SaveChangesAsync();
            return Ok();
        }
    }
}