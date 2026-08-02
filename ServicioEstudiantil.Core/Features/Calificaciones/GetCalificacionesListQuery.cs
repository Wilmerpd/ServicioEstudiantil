using MediatR;
using Microsoft.EntityFrameworkCore;
using ServicioEstudiantil.Core.Common;
using ServicioEstudiantil.Core.DTOs;

namespace ServicioEstudiantil.Core.Features.Calificaciones.Queries.GetCalificacionesList;

public record GetCalificacionesListQuery : IRequest<Result<List<CalificacionDTO>>>;

public class GetCalificacionesListQueryHandler : IRequestHandler<GetCalificacionesListQuery, Result<List<CalificacionDTO>>>
{
    private readonly IAppDbContext _context;

    public GetCalificacionesListQueryHandler(IAppDbContext context)
    {
        _context = context;
    }

    public async Task<Result<List<CalificacionDTO>>> Handle(GetCalificacionesListQuery request, CancellationToken cancellationToken)
    {
        var calificaciones = await _context.Calificaciones
            .Include(c => c.Estudiante)
            .Include(c => c.Asignatura)
            .Select(c => new CalificacionDTO
            {
                Id = c.Id,
                EstudianteId = c.EstudianteId,
                NombreEstudiante = c.Estudiante != null ? $"{c.Estudiante.Nombres} {c.Estudiante.Apellidos}" : "N/A",
                AsignaturaId = c.AsignaturaId,
                NombreAsignatura = c.Asignatura != null ? c.Asignatura.Nombre : "N/A",
                Nota = c.Nota,
                Periodo = c.Periodo
            })
            .ToListAsync(cancellationToken);

        return Result<List<CalificacionDTO>>.Success(calificaciones);
    }
}