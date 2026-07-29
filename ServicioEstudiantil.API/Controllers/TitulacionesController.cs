using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ServicioEstudiantil.Core.DTOs;
using ServicioEstudiantil.Core.Entities;
using ServicioEstudiantil.Infrastructure.Data;

namespace ServicioEstudiantil.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TitulacionesController : ControllerBase
    {
        private readonly AppDbContext _context;

        public TitulacionesController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/Titulaciones
        [HttpGet]
        public async Task<ActionResult<List<TitulacionDTO>>> GetTitulaciones()
        {
            var titulaciones = await _context.Titulaciones
                .Select(t => new TitulacionDTO
                {
                    Id = t.Id,
                    Nombre = t.Nombre,
                    Codigo = t.Codigo
                }).ToListAsync();

            return Ok(titulaciones);
        }

        // GET: api/Titulaciones/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TitulacionDTO>> GetTitulacion(int id)
        {
            var titulacion = await _context.Titulaciones.FindAsync(id);

            if (titulacion == null)
            {
                return NotFound();
            }

            var titulacionDTO = new TitulacionDTO
            {
                Id = titulacion.Id,
                Nombre = titulacion.Nombre,
                Codigo = titulacion.Codigo
            };

            return Ok(titulacionDTO);
        }

        // POST: api/Titulaciones
        [HttpPost]
        public async Task<ActionResult<TitulacionDTO>> PostTitulacion(TitulacionInputDTO dto)
        {
            var titulacion = new Titulacion
            {
                Nombre = dto.Nombre,
                Codigo = dto.Codigo
            };

            _context.Titulaciones.Add(titulacion);
            await _context.SaveChangesAsync();

            var resultado = new TitulacionDTO
            {
                Id = titulacion.Id,
                Nombre = titulacion.Nombre,
                Codigo = titulacion.Codigo
            };

            return CreatedAtAction(nameof(GetTitulacion), new { id = titulacion.Id }, resultado);
        }

        // PUT: api/Titulaciones/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTitulacion(int id, TitulacionInputDTO dto)
        {
            var titulacion = await _context.Titulaciones.FindAsync(id);

            if (titulacion == null)
            {
                return NotFound();
            }

            titulacion.Nombre = dto.Nombre;
            titulacion.Codigo = dto.Codigo;

            await _context.SaveChangesAsync();

            return NoContent();
        }

        // DELETE: api/Titulaciones/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTitulacion(int id)
        {
            var titulacion = await _context.Titulaciones.FindAsync(id);

            if (titulacion == null)
            {
                return NotFound();
            }

            _context.Titulaciones.Remove(titulacion);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
