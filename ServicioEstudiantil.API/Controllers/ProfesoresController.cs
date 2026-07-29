using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ServicioEstudiantil.Core.DTOs;
using ServicioEstudiantil.Core.Entities;
using ServicioEstudiantil.Infrastructure.Data;

namespace ServicioEstudiantil.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProfesoresController : ControllerBase
    {
        private readonly AppDbContext _context;

        public ProfesoresController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/Profesores
        [HttpGet]
        public async Task<ActionResult<List<ProfesorDTO>>> GetProfesores()
        {
            var profesores = await _context.Profesores
                .Select(p => new ProfesorDTO
                {
                    Id = p.Id,
                    NombreCompleto = p.Nombres + " " + p.Apellidos,
                    CorreoContacto = p.CorreoContacto,
                    Departamento = p.Departamento
                }).ToListAsync();

            return Ok(profesores);
        }

        // GET: api/Profesores/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ProfesorDTO>> GetProfesor(int id)
        {
            var profesor = await _context.Profesores.FindAsync(id);

            if (profesor == null)
            {
                return NotFound();
            }

            var profesorDTO = new ProfesorDTO
            {
                Id = profesor.Id,
                NombreCompleto = profesor.Nombres + " " + profesor.Apellidos,
                CorreoContacto = profesor.CorreoContacto,
                Departamento = profesor.Departamento
            };

            return Ok(profesorDTO);
        }

        // POST: api/Profesores
        [HttpPost]
        public async Task<ActionResult<ProfesorDTO>> PostProfesor(ProfesorInputDTO dto)
        {
            var profesor = new Profesor
            {
                Nombres = dto.Nombres,
                Apellidos = dto.Apellidos,
                CorreoContacto = dto.CorreoContacto,
                Departamento = dto.Departamento
            };

            _context.Profesores.Add(profesor);
            await _context.SaveChangesAsync();

            var resultado = new ProfesorDTO
            {
                Id = profesor.Id,
                NombreCompleto = profesor.Nombres + " " + profesor.Apellidos,
                CorreoContacto = profesor.CorreoContacto,
                Departamento = profesor.Departamento
            };

            return CreatedAtAction(nameof(GetProfesor), new { id = profesor.Id }, resultado);
        }

        // PUT: api/Profesores/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutProfesor(int id, ProfesorInputDTO dto)
        {
            var profesor = await _context.Profesores.FindAsync(id);

            if (profesor == null)
            {
                return NotFound();
            }

            profesor.Nombres = dto.Nombres;
            profesor.Apellidos = dto.Apellidos;
            profesor.CorreoContacto = dto.CorreoContacto;
            profesor.Departamento = dto.Departamento;

            await _context.SaveChangesAsync();

            return NoContent();
        }

        // DELETE: api/Profesores/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProfesor(int id)
        {
            var profesor = await _context.Profesores.FindAsync(id);

            if (profesor == null)
            {
                return NotFound();
            }

            _context.Profesores.Remove(profesor);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
