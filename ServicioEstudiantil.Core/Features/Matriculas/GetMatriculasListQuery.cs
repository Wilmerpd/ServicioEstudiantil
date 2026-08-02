using MediatR;
using Microsoft.EntityFrameworkCore;
using ServicioEstudiantil.Core.Common;
using ServicioEstudiantil.Core.DTOs;

namespace ServicioEstudiantil.Core.Features.Matriculas.Queries.GetMatriculasList;

public record GetMatriculasListQuery : IRequest<Result<List<MatriculaDTO>>>;

public class GetMatriculasListQueryHandler : IRequestHandler<GetMatriculasListQuery, Result<List<MatriculaDTO>>>
{
    private readonly IAppDbContext _context;

    public GetMatriculasListQueryHandler(IAppDbContext context)
    {
        _context = context;
    }

    public async Task<Result<List<MatriculaDTO>>> Handle(GetMatriculasListQuery request, CancellationToken cancellationToken)
    {
        var matriculas = await _context.Matriculas
            .Include(m => m.Estudiante)
            .Include(m => m.Asignatura)
            .Select(m => new MatriculaDTO
            {
                Id = m.Id,
                EstudianteId = m.EstudianteId,
                NombreEstudiante = m.Estudiante != null ? $"{m.Estudiante.Nombres} {m.Estudiante.Apellidos}" : "N/A",
                AsignaturaId = m.AsignaturaId,
                NombreAsignatura = m.Asignatura != null ? m.Asignatura.Nombre : "N/A",
                Periodo = m.Periodo,
                FechaInscripcion = m.FechaInscripcion
            })
            .ToListAsync(cancellationToken);

        return Result<List<MatriculaDTO>>.Success(matriculas);
    }
}