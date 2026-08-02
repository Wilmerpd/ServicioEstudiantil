using MediatR;
using ServicioEstudiantil.Core.Common;
using ServicioEstudiantil.Core.Entities;

namespace ServicioEstudiantil.Core.Features.Calificaciones.Commands.CreateCalificacion;

public record CreateCalificacionCommand(
    int EstudianteId,
    int AsignaturaId,
    decimal Nota,
    string Periodo
) : IRequest<Result<int>>;

public class CreateCalificacionCommandHandler : IRequestHandler<CreateCalificacionCommand, Result<int>>
{
    private readonly IAppDbContext _context;

    public CreateCalificacionCommandHandler(IAppDbContext context)
    {
        _context = context;
    }

    public async Task<Result<int>> Handle(CreateCalificacionCommand request, CancellationToken cancellationToken)
    {
        var calificacion = new Calificacion
        {
            EstudianteId = request.EstudianteId,
            AsignaturaId = request.AsignaturaId,
            Nota = request.Nota,
            Periodo = request.Periodo
        };

        _context.Calificaciones.Add(calificacion);
        await _context.SaveChangesAsync(cancellationToken);

        return Result<int>.Success(calificacion.Id);
    }
}