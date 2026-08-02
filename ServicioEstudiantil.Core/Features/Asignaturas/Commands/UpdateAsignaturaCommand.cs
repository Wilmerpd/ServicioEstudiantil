using MediatR;
using ServicioEstudiantil.Core.Common;

namespace ServicioEstudiantil.Core.Features.Asignaturas.Commands.UpdateAsignatura;

public record UpdateAsignaturaCommand(
    int Id,
    string Codigo,
    string Nombre,
    int Creditos,
    string Departamento
) : IRequest<Result<bool>>;

public class UpdateAsignaturaCommandHandler : IRequestHandler<UpdateAsignaturaCommand, Result<bool>>
{
    private readonly IAppDbContext _context;

    public UpdateAsignaturaCommandHandler(IAppDbContext context)
    {
        _context = context;
    }

    public async Task<Result<bool>> Handle(UpdateAsignaturaCommand request, CancellationToken cancellationToken)
    {
        var asignatura = await _context.Asignaturas.FindAsync(new object[] { request.Id }, cancellationToken);

        if (asignatura == null)
            return Result<bool>.Failure("Asignatura no encontrada.");

        asignatura.Codigo = request.Codigo;
        asignatura.Nombre = request.Nombre;
        asignatura.Creditos = request.Creditos;
        asignatura.Departamento = request.Departamento;

        await _context.SaveChangesAsync(cancellationToken);

        return Result<bool>.Success(true);
    }
}