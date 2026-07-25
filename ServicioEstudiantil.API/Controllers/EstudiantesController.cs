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
                    EstaActivo = e.EstaActivo
                }).ToListAsync();

            return Ok(estudiantes);
        }
    }
}