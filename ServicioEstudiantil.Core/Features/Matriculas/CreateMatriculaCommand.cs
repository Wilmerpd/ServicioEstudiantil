using MediatR;
using ServicioEstudiantil.Core.Common;
using ServicioEstudiantil.Core.Entities;

namespace ServicioEstudiantil.Core.Features.Matriculas.Commands.CreateMatricula;

public record CreateMatriculaCommand(
    int EstudianteId,
    int AsignaturaId,
    string Periodo
) : IRequest<Result<int>>;

public class CreateMatriculaCommandHandler : IRequestHandler<CreateMatriculaCommand, Result<int>>
{
    private readonly IAppDbContext _context;

    public CreateMatriculaCommandHandler(IAppDbContext context)
    {
        _context = context;
    }

    public async Task<Result<int>> Handle(CreateMatriculaCommand request, CancellationToken cancellationToken)
    {
        var matricula = new Matricula
        {
            EstudianteId = request.EstudianteId,
            AsignaturaId = request.AsignaturaId,
            Periodo = request.Periodo,
            FechaInscripcion = DateTime.UtcNow
        };

        _context.Matriculas.Add(matricula);
        await _context.SaveChangesAsync(cancellationToken);

        return Result<int>.Success(matricula.Id);
    }
}