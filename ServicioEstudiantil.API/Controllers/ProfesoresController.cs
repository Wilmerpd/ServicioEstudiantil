using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ServicioEstudiantil.Core.Features.Profesores.Commands.CreateProfesor;
using ServicioEstudiantil.Core.Features.Profesores.Commands.UpdateProfesor;
using ServicioEstudiantil.Core.Features.Profesores.Queries.GetProfesoresList;
using ServicioEstudiantil.Infrastructure.Data;


namespace ServicioEstudiantil.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ProfesoresController : ControllerBase
{
    private readonly IMediator _mediator;
    private readonly AppDbContext _context;

    public ProfesoresController(IMediator mediator, AppDbContext context)
    {
        _mediator = mediator;
        _context = context;
    }

    [HttpGet]
    public async Task<IActionResult> Get()
    {
        var result = await _mediator.Send(new GetProfesoresListQuery());
        return Ok(result.Value);
    }

    [HttpPost]
    public async Task<IActionResult> Post(CreateProfesorCommand command)
    {
        var result = await _mediator.Send(command);
        return Ok(result);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Put(int id, UpdateProfesorCommand command)
    {
        if (id != command.Id) return BadRequest("El ID no coincide.");
        var result = await _mediator.Send(command);
        return Ok(result);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var profesor = await _context.Profesores.FindAsync(id);
        if (profesor == null) return NotFound();

        _context.Profesores.Remove(profesor);
        await _context.SaveChangesAsync();

        return Ok(true);
    }
}