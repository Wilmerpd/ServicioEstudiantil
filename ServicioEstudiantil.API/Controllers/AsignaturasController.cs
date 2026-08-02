using MediatR;
using Microsoft.AspNetCore.Mvc;
using ServicioEstudiantil.Core.Common;
using ServicioEstudiantil.Core.Features.Asignaturas.Commands.CreateAsignatura;
using ServicioEstudiantil.Core.Features.Asignaturas.Commands.UpdateAsignatura;
using ServicioEstudiantil.Core.Features.Asignaturas.Queries.GetAsignaturasList;

namespace ServicioEstudiantil.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AsignaturasController : ControllerBase
{
    private readonly IMediator _mediator;
    private readonly IAppDbContext _context;

    public AsignaturasController(IMediator mediator, IAppDbContext context)
    {
        _mediator = mediator;
        _context = context;
    }

    [HttpGet]
    public async Task<IActionResult> Get()
    {
        var result = await _mediator.Send(new GetAsignaturasListQuery());
        return Ok(result.Value);
    }

    [HttpPost]
    public async Task<IActionResult> Post(CreateAsignaturaCommand command)
    {
        var result = await _mediator.Send(command);
        return Ok(result);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Put(int id, UpdateAsignaturaCommand command)
    {
        if (id != command.Id) return BadRequest("El ID no coincide.");
        var result = await _mediator.Send(command);
        return Ok(result);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var asignatura = await _context.Asignaturas.FindAsync(id);
        if (asignatura == null) return NotFound();

        _context.Asignaturas.Remove(asignatura);
        await _context.SaveChangesAsync(default);

        return Ok(true);
    }
}