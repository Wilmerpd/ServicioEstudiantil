using MediatR;
using Microsoft.EntityFrameworkCore;
using ServicioEstudiantil.Core.Common;

namespace ServicioEstudiantil.Core.Features.Estudiantes.Queries.GetEstudiantesList;

public record GetEstudiantesListQuery : IRequest<Result<List<EstudianteDto>>>;

public record EstudianteDto(int Id, string Matricula, string NombreCompleto, string Correo);

public class GetEstudiantesListQueryHandler : IRequestHandler<GetEstudiantesListQuery, Result<List<EstudianteDto>>>
{
    private readonly IAppDbContext _context;

    public GetEstudiantesListQueryHandler(IAppDbContext context)
    {
        _context = context;
    }

    public async Task<Result<List<EstudianteDto>>> Handle(GetEstudiantesListQuery request, CancellationToken cancellationToken)
    {
        var estudiantes = await _context.Estudiantes
            .Select(e => new EstudianteDto(
                e.Id,
                e.Matricula,
                e.Nombres + " " + e.Apellidos,
                e.CorreoInstitucional
            ))
            .ToListAsync(cancellationToken);

        return Result<List<EstudianteDto>>.Success(estudiantes);
    }
}