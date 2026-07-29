using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ServicioEstudiantil.Core.DTOs;
using ServicioEstudiantil.Core.Entities;
using ServicioEstudiantil.Infrastructure.Data;

namespace ServicioEstudiantil.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AsignaturasController : ControllerBase
    {
        private readonly AppDbContext _context;

        public AsignaturasController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/Asignaturas
        [HttpGet]
        public async Task<ActionResult<List<AsignaturaDTO>>> GetAsignaturas()
        {
            // Incluimos Titulacion y Profesor porque el DTO necesita sus nombres
            var asignaturas = await _context.Asignaturas
                .Include(a => a.Titulacion)
                .Include(a => a.Profesor)
                .Select(a => new AsignaturaDTO
                {
                    Id = a.Id,
                    Nombre = a.Nombre,
                    Creditos = a.Creditos,
                    NombreTitulacion = a.Titulacion != null ? a.Titulacion.Nombre : string.Empty,
                    NombreProfesor = a.Profesor != null ? a.Profesor.Nombres + " " + a.Profesor.Apellidos : string.Empty
                }).ToListAsync();

            return Ok(asignaturas);
        }

        // GET: api/Asignaturas/5
        [HttpGet("{id}")]
        public async Task<ActionResult<AsignaturaDTO>> GetAsignatura(int id)
        {
            var asignatura = await _context.Asignaturas
                .Include(a => a.Titulacion)
                .Include(a => a.Profesor)
                .FirstOrDefaultAsync(a => a.Id == id);

            if (asignatura == null)
            {
                return NotFound();
            }

            var asignaturaDTO = new AsignaturaDTO
            {
                Id = asignatura.Id,
                Nombre = asignatura.Nombre,
                Creditos = asignatura.Creditos,
                NombreTitulacion = asignatura.Titulacion != null ? asignatura.Titulacion.Nombre : string.Empty,
                NombreProfesor = asignatura.Profesor != null ? asignatura.Profesor.Nombres + " " + asignatura.Profesor.Apellidos : string.Empty
            };

            return Ok(asignaturaDTO);
        }

        // POST: api/Asignaturas
        [HttpPost]
        public async Task<ActionResult<AsignaturaDTO>> PostAsignatura(AsignaturaInputDTO dto)
        {
            var asignatura = new Asignatura
            {
                Nombre = dto.Nombre,
                Creditos = dto.Creditos,
                TitulacionId = dto.TitulacionId,
                ProfesorId = dto.ProfesorId
            };

            _context.Asignaturas.Add(asignatura);
            await _context.SaveChangesAsync();

            // Recargamos con Include para poder devolver los nombres en la respuesta
            await _context.Entry(asignatura).Reference(a => a.Titulacion).LoadAsync();
            await _context.Entry(asignatura).Reference(a => a.Profesor).LoadAsync();

            var resultado = new AsignaturaDTO
            {
                Id = asignatura.Id,
                Nombre = asignatura.Nombre,
                Creditos = asignatura.Creditos,
                NombreTitulacion = asignatura.Titulacion != null ? asignatura.Titulacion.Nombre : string.Empty,
                NombreProfesor = asignatura.Profesor != null ? asignatura.Profesor.Nombres + " " + asignatura.Profesor.Apellidos : string.Empty
            };

            return CreatedAtAction(nameof(GetAsignatura), new { id = asignatura.Id }, resultado);
        }

        // PUT: api/Asignaturas/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAsignatura(int id, AsignaturaInputDTO dto)
        {
            var asignatura = await _context.Asignaturas.FindAsync(id);

            if (asignatura == null)
            {
                return NotFound();
            }

            asignatura.Nombre = dto.Nombre;
            asignatura.Creditos = dto.Creditos;
            asignatura.TitulacionId = dto.TitulacionId;
            asignatura.ProfesorId = dto.ProfesorId;

            await _context.SaveChangesAsync();

            return NoContent();
        }

        // DELETE: api/Asignaturas/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsignatura(int id)
        {
            var asignatura = await _context.Asignaturas.FindAsync(id);

            if (asignatura == null)
            {
                return NotFound();
            }

            _context.Asignaturas.Remove(asignatura);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
