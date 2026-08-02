using MediatR;
using ServicioEstudiantil.Core.Common;
using ServicioEstudiantil.Core.Entities;

namespace ServicioEstudiantil.Core.Features.Profesores.Commands.CreateProfesor;

public record CreateProfesorCommand(
    string Identificacion,
    string Nombres,
    string Apellidos,
    string Correo,
    string Departamento
) : IRequest<Result<int>>;

public class CreateProfesorCommandHandler : IRequestHandler<CreateProfesorCommand, Result<int>>
{
    private readonly IAppDbContext _context;

    public CreateProfesorCommandHandler(IAppDbContext context)
    {
        _context = context;
    }

    public async Task<Result<int>> Handle(CreateProfesorCommand request, CancellationToken cancellationToken)
    {
        var profesor = new Profesor
        {
            Identificacion = request.Identificacion,
            Nombres = request.Nombres,
            Apellidos = request.Apellidos,
            Correo = request.Correo,
            Departamento = request.Departamento
        };

        _context.Profesores.Add(profesor);
        await _context.SaveChangesAsync(cancellationToken);

        return Result<int>.Success(profesor.Id);
    }
}