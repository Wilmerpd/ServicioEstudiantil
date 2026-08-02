using MediatR;
using Microsoft.AspNetCore.Mvc;
using ServicioEstudiantil.Core.Common;
using ServicioEstudiantil.Core.Features.Matriculas.Commands.CreateMatricula;
using ServicioEstudiantil.Core.Features.Matriculas.Queries.GetMatriculasList;

namespace ServicioEstudiantil.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class MatriculasController : ControllerBase
{
    private readonly IMediator _mediator;
    private readonly IAppDbContext _context;

    public MatriculasController(IMediator mediator, IAppDbContext context)
    {
        _mediator = mediator;
        _context = context;
    }

    [HttpGet]
    public async Task<IActionResult> Get()
    {
        var result = await _mediator.Send(new GetMatriculasListQuery());
        return Ok(result.Value);
    }

    [HttpPost]
    public async Task<IActionResult> Post(CreateMatriculaCommand command)
    {
        var result = await _mediator.Send(command);
        return Ok(result);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var matricula = await _context.Matriculas.FindAsync(id);
        if (matricula == null) return NotFound();

        _context.Matriculas.Remove(matricula);
        await _context.SaveChangesAsync(default);

        return Ok(true);
    }
}