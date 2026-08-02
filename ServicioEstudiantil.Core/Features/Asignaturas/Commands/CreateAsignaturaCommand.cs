using MediatR;
using ServicioEstudiantil.Core.Common;
using ServicioEstudiantil.Core.Entities;

namespace ServicioEstudiantil.Core.Features.Asignaturas.Commands.CreateAsignatura;

public record CreateAsignaturaCommand(
    string Codigo,
    string Nombre,
    int Creditos,
    string Departamento
) : IRequest<Result<int>>;

public class CreateAsignaturaCommandHandler : IRequestHandler<CreateAsignaturaCommand, Result<int>>
{
    private readonly IAppDbContext _context;

    public CreateAsignaturaCommandHandler(IAppDbContext context)
    {
        _context = context;
    }

    public async Task<Result<int>> Handle(CreateAsignaturaCommand request, CancellationToken cancellationToken)
    {
        var asignatura = new Asignatura
        {
            Codigo = request.Codigo,
            Nombre = request.Nombre,
            Creditos = request.Creditos,
            Departamento = request.Departamento
        };

        _context.Asignaturas.Add(asignatura);
        await _context.SaveChangesAsync(cancellationToken);

        return Result<int>.Success(asignatura.Id);
    }
}