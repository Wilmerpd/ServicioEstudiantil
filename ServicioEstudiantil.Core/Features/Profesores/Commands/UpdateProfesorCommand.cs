using MediatR;
using ServicioEstudiantil.Core.Common;

namespace ServicioEstudiantil.Core.Features.Profesores.Commands.UpdateProfesor;

public record UpdateProfesorCommand(
    int Id,
    string Identificacion,
    string Nombres,
    string Apellidos,
    string Correo,
    string Departamento
) : IRequest<Result<bool>>;

public class UpdateProfesorCommandHandler : IRequestHandler<UpdateProfesorCommand, Result<bool>>
{
    private readonly IAppDbContext _context;

    public UpdateProfesorCommandHandler(IAppDbContext context)
    {
        _context = context;
    }

    public async Task<Result<bool>> Handle(UpdateProfesorCommand request, CancellationToken cancellationToken)
    {
        var profesor = await _context.Profesores.FindAsync(new object[] { request.Id }, cancellationToken);

        if (profesor == null)
            return Result<bool>.Failure("Profesor no encontrado.");

        profesor.Identificacion = request.Identificacion;
        profesor.Nombres = request.Nombres;
        profesor.Apellidos = request.Apellidos;
        profesor.Correo = request.Correo;
        profesor.Departamento = request.Departamento;

        await _context.SaveChangesAsync(cancellationToken);

        return Result<bool>.Success(true);
    }
}