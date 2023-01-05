using ApiHospital.DTOs;
using ApiHospital.Entidades;
using AutoMapper;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Xml.Linq;

namespace ApiHospital.Controllers
{
    [ApiController]
    [Route("enfermedades/{enfermedadID:int}/enfermedad")]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class EnfermedadController : ControllerBase
    {
        private readonly ApplicationDbContext dbContext;
        private readonly IMapper mapper;
        private readonly UserManager<IdentityUser> userManager;

        public EnfermedadController(ApplicationDbContext dbContext, IMapper mapper,
            UserManager<IdentityUser> userManager)
        {
            this.dbContext = dbContext;
            this.mapper = mapper;
            this.userManager = userManager;
        }

        [HttpGet("test")]
        public async Task<ActionResult<List<EnfermedadDTO>>> Get(int pacienteId)
        {
            var existePaciente = await dbContext.Pacientes.AnyAsync(pacienteDB => pacienteDB.IdPaciente == pacienteId);
            if (!existePaciente)
            {
                return NotFound();
            }

            var enfermedad = await dbContext.Enfermedades.Where(enfermedadDB => enfermedadDB.Id == pacienteId).ToListAsync();

            return mapper.Map<List<EnfermedadDTO>>(enfermedad);
        }

        [HttpGet("{id:int}", Name = "obtenerEnfermedad")]
        public async Task<ActionResult<EnfermedadDTO>> GetById(int id)
        {
            var enfermedad = await dbContext.Enfermedades.FirstOrDefaultAsync(enfermedadDB => enfermedadDB.Id == id);

            if (enfermedad == null)
            {
                return NotFound();
            }

            return mapper.Map<EnfermedadDTO>(enfermedad);
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<ActionResult> Post(int enfermedadId, EnfermedadCreacionDTO enfermedadCreacionDTO)
        {
            var emailClaim = HttpContext.User.Claims.Where(claim => claim.Type == "email").FirstOrDefault();

            var email = emailClaim.Value;

            var usuario = await userManager.FindByEmailAsync(email);
            var usuarioId = usuario.Id;

            var existeEnfermedad= await dbContext.Enfermedades.AnyAsync(enfermedadDB => enfermedadDB.Id == enfermedadId);
            if (!existeEnfermedad)
            {
                return NotFound();
            }

            var enfermedad = mapper.Map<Enfermedad>(enfermedadCreacionDTO);
            enfermedad.EnfermedadId = enfermedadId;
            enfermedad.UsuarioId = usuarioId;
            dbContext.Add(enfermedad);
            await dbContext.SaveChangesAsync();

            var enfermedadDTO = mapper.Map<EnfermedadDTO>(enfermedad);

            return CreatedAtRoute("obtenerEnfermedad", new { id = enfermedad.Id, enfermedadId = enfermedadId  }, enfermedadDTO);
        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult> Put(int pacienteid, int id, EnfermedadCreacionDTO enfermedadCreacionDTO)
        {
            var existePaciente = await dbContext.Enfermedades.AnyAsync(PacienteDB => PacienteDB.Id == pacienteid);
            if (!existePaciente)
            {
                return NotFound();
            }

            var existeEnfermedad = await dbContext.Enfermedades.AnyAsync(EnfermedadDB => EnfermedadDB.Id == id);
            if (!existeEnfermedad)
            {
                return NotFound();
            }

            var enfermedad = mapper.Map<Enfermedad>(enfermedadCreacionDTO);
            enfermedad.Id = id;
            enfermedad.EnfermedadId = pacienteid;

            dbContext.Update(enfermedad);
            await dbContext.SaveChangesAsync();
            return NoContent();
        }
    }
}

