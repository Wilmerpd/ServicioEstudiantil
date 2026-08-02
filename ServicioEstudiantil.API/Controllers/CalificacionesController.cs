using MediatR;
using Microsoft.AspNetCore.Mvc;
using ServicioEstudiantil.Core.Common;
using ServicioEstudiantil.Core.Features.Calificaciones.Commands.CreateCalificacion;
using ServicioEstudiantil.Core.Features.Calificaciones.Queries.GetCalificacionesList;

namespace ServicioEstudiantil.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CalificacionesController : ControllerBase
{
    private readonly IMediator _mediator;
    private readonly IAppDbContext _context;

    public CalificacionesController(IMediator mediator, IAppDbContext context)
    {
        _mediator = mediator;
        _context = context;
    }

    [HttpGet]
    public async Task<IActionResult> Get()
    {
        var result = await _mediator.Send(new GetCalificacionesListQuery());
        return Ok(result.Value);
    }

    [HttpPost]
    public async Task<IActionResult> Post(CreateCalificacionCommand command)
    {
        var result = await _mediator.Send(command);
        return Ok(result);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var calificacion = await _context.Calificaciones.FindAsync(id);
        if (calificacion == null) return NotFound();

        _context.Calificaciones.Remove(calificacion);
        await _context.SaveChangesAsync(default);

        return Ok(true);
    }
}