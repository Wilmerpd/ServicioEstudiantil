using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ServicioEstudiantil.Core.DTOs;
using ServicioEstudiantil.Core.Entities;
using ServicioEstudiantil.Infrastructure.Data;

namespace ServicioEstudiantil.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EstudiantesController : ControllerBase
    {
        private readonly AppDbContext _context;

        // Inyectamos la base de datos
        public EstudiantesController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/Estudiantes
        [HttpGet]
        public async Task<ActionResult<List<EstudianteDTO>>> GetEstudiantes()
        {
            // Buscamos en la BD y convertimos la Entidad a DTO para enviarla al cliente
            var estudiantes = await _context.Estudiantes
                .Select(e => new EstudianteDTO
                {
                    Id = e.Id,
                    Matricula = e.Matricula,
                    Nombres = e.Nombres,
                    Apellidos = e.Apellidos,
                    CorreoInstitucional = e.CorreoInstitucional,
                    EstaActivo = e.EstaActivo,
                    TitulacionId = e.TitulacionId
                }).ToListAsync();

            return Ok(estudiantes);
        }

        // GET: api/Estudiantes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<EstudianteDTO>> GetEstudiante(int id)
        {
            var estudiante = await _context.Estudiantes.FindAsync(id);

            if (estudiante == null)
            {
                return NotFound();
            }

            var estudianteDTO = new EstudianteDTO
            {
                Id = estudiante.Id,
                Matricula = estudiante.Matricula,
                Nombres = estudiante.Nombres,
                Apellidos = estudiante.Apellidos,
                CorreoInstitucional = estudiante.CorreoInstitucional,
                EstaActivo = estudiante.EstaActivo,
                TitulacionId = estudiante.TitulacionId
            };

            return Ok(estudianteDTO);
        }

        // POST: api/Estudiantes
        [HttpPost]
        public async Task<ActionResult<EstudianteDTO>> PostEstudiante(EstudianteDTO dto)
        {
            // Convertimos el DTO recibido en una Entidad para guardarla en la BD
            var estudiante = new Estudiante
            {
                Matricula = dto.Matricula,
                Nombres = dto.Nombres,
                Apellidos = dto.Apellidos,
                CorreoInstitucional = dto.CorreoInstitucional,
                EstaActivo = dto.EstaActivo,
                TitulacionId = dto.TitulacionId
            };

            _context.Estudiantes.Add(estudiante);
            await _context.SaveChangesAsync();

            // Actualizamos el DTO con el Id generado por la BD
            dto.Id = estudiante.Id;

            // Devolvemos 201 Created + la ruta para consultar el nuevo recurso
            return CreatedAtAction(nameof(GetEstudiante), new { id = estudiante.Id }, dto);
        }

        // PUT: api/Estudiantes/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutEstudiante(int id, EstudianteDTO dto)
        {
            if (id != dto.Id)
            {
                return BadRequest("El id de la URL no coincide con el id del cuerpo enviado.");
            }

            var estudiante = await _context.Estudiantes.FindAsync(id);

            if (estudiante == null)
            {
                return NotFound();
            }

            // Actualizamos los campos de la entidad con los datos del DTO
            estudiante.Matricula = dto.Matricula;
            estudiante.Nombres = dto.Nombres;
            estudiante.Apellidos = dto.Apellidos;
            estudiante.CorreoInstitucional = dto.CorreoInstitucional;
            estudiante.EstaActivo = dto.EstaActivo;
            estudiante.TitulacionId = dto.TitulacionId;

            await _context.SaveChangesAsync();

            // 204 No Content: la actualización fue exitosa y no hay nada más que devolver
            return NoContent();
        }

        // DELETE: api/Estudiantes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEstudiante(int id)
        {
            var estudiante = await _context.Estudiantes.FindAsync(id);

            if (estudiante == null)
            {
                return NotFound();
            }

            _context.Estudiantes.Remove(estudiante);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}