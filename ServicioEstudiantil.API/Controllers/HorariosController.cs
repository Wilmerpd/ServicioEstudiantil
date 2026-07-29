using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ServicioEstudiantil.Core.DTOs;
using ServicioEstudiantil.Core.Entities;
using ServicioEstudiantil.Infrastructure.Data;

namespace ServicioEstudiantil.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HorariosController : ControllerBase
    {
        private readonly AppDbContext _context;

        public HorariosController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/Horarios
        [HttpGet]
        public async Task<ActionResult<List<HorarioDTO>>> GetHorarios()
        {
            var horarios = await _context.Horarios
                .Include(h => h.Asignatura)
                .Select(h => new HorarioDTO
                {
                    Id = h.Id,
                    DiaSemana = h.DiaSemana,
                    HoraInicio = h.HoraInicio,
                    HoraFin = h.HoraFin,
                    Aula = h.Aula,
                    NombreAsignatura = h.Asignatura != null ? h.Asignatura.Nombre : string.Empty
                }).ToListAsync();

            return Ok(horarios);
        }

        // GET: api/Horarios/5
        [HttpGet("{id}")]
        public async Task<ActionResult<HorarioDTO>> GetHorario(int id)
        {
            var horario = await _context.Horarios
                .Include(h => h.Asignatura)
                .FirstOrDefaultAsync(h => h.Id == id);

            if (horario == null)
            {
                return NotFound();
            }

            var horarioDTO = new HorarioDTO
            {
                Id = horario.Id,
                DiaSemana = horario.DiaSemana,
                HoraInicio = horario.HoraInicio,
                HoraFin = horario.HoraFin,
                Aula = horario.Aula,
                NombreAsignatura = horario.Asignatura != null ? horario.Asignatura.Nombre : string.Empty
            };

            return Ok(horarioDTO);
        }

        // POST: api/Horarios
        [HttpPost]
        public async Task<ActionResult<HorarioDTO>> PostHorario(HorarioInputDTO dto)
        {
            var horario = new Horario
            {
                DiaSemana = dto.DiaSemana,
                HoraInicio = dto.HoraInicio,
                HoraFin = dto.HoraFin,
                Aula = dto.Aula,
                AsignaturaId = dto.AsignaturaId
            };

            _context.Horarios.Add(horario);
            await _context.SaveChangesAsync();

            await _context.Entry(horario).Reference(h => h.Asignatura).LoadAsync();

            var resultado = new HorarioDTO
            {
                Id = horario.Id,
                DiaSemana = horario.DiaSemana,
                HoraInicio = horario.HoraInicio,
                HoraFin = horario.HoraFin,
                Aula = horario.Aula,
                NombreAsignatura = horario.Asignatura != null ? horario.Asignatura.Nombre : string.Empty
            };

            return CreatedAtAction(nameof(GetHorario), new { id = horario.Id }, resultado);
        }

        // PUT: api/Horarios/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutHorario(int id, HorarioInputDTO dto)
        {
            var horario = await _context.Horarios.FindAsync(id);

            if (horario == null)
            {
                return NotFound();
            }

            horario.DiaSemana = dto.DiaSemana;
            horario.HoraInicio = dto.HoraInicio;
            horario.HoraFin = dto.HoraFin;
            horario.Aula = dto.Aula;
            horario.AsignaturaId = dto.AsignaturaId;

            await _context.SaveChangesAsync();

            return NoContent();
        }

        // DELETE: api/Horarios/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteHorario(int id)
        {
            var horario = await _context.Horarios.FindAsync(id);

            if (horario == null)
            {
                return NotFound();
            }

            _context.Horarios.Remove(horario);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
