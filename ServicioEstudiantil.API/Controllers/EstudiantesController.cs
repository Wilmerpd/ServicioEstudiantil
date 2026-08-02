using MediatR;
using Microsoft.AspNetCore.Mvc;
using ServicioEstudiantil.Core.Features.Estudiantes.Commands.CreateEstudiante;
using ServicioEstudiantil.Core.Features.Estudiantes.Commands.DeleteEstudiante;
using ServicioEstudiantil.Core.Features.Estudiantes.Commands.UpdateEstudiante;
using ServicioEstudiantil.Core.Features.Estudiantes.Queries.GetEstudianteById;
using ServicioEstudiantil.Core.Features.Estudiantes.Queries.GetEstudiantesList;

namespace ServicioEstudiantil.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class EstudiantesController : ControllerBase
{
    private readonly IMediator _mediator;

    public EstudiantesController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var result = await _mediator.Send(new GetEstudiantesListQuery());
        return result.IsSuccess ? Ok(result.Value) : BadRequest(new { mensaje = result.ErrorMessage });
    }

    [HttpGet("{id:int}")]
    public async Task<IActionResult> GetById(int id)
    {
        var result = await _mediator.Send(new GetEstudianteByIdQuery(id));
        return result.IsSuccess ? Ok(result.Value) : BadRequest(new { mensaje = result.ErrorMessage });
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateEstudianteCommand command)
    {
        var result = await _mediator.Send(command);
        return result.IsSuccess
            ? Ok(new { id = result.Value, mensaje = "Estudiante creado exitosamente." })
            : BadRequest(new { mensaje = result.ErrorMessage });
    }

    [HttpPut("{id:int}")]
    public async Task<IActionResult> Update(int id, [FromBody] UpdateEstudianteCommand command)
    {
        if (id != command.Id)
        {
            return BadRequest(new { mensaje = "El ID de la URL no coincide con el ID del cuerpo." });
        }

        var result = await _mediator.Send(command);
        return result.IsSuccess ? Ok(new { mensaje = "Estudiante actualizado correctamente." }) : BadRequest(new { mensaje = result.ErrorMessage });
    }

    [HttpDelete("{id:int}")]
    public async Task<IActionResult> Delete(int id)
    {
        var result = await _mediator.Send(new DeleteEstudianteCommand(id));
        return result.IsSuccess ? Ok(new { mensaje = "Estudiante eliminado correctamente." }) : BadRequest(new { mensaje = result.ErrorMessage });
    }
}