using MediatR;
using Microsoft.EntityFrameworkCore;
using ServicioEstudiantil.Core.Common;
using ServicioEstudiantil.Core.DTOs;

namespace ServicioEstudiantil.Core.Features.Profesores.Queries.GetProfesoresList;

public record GetProfesoresListQuery : IRequest<Result<List<ProfesorDTO>>>;

public class GetProfesoresListQueryHandler : IRequestHandler<GetProfesoresListQuery, Result<List<ProfesorDTO>>>
{
    private readonly IAppDbContext _context;

    public GetProfesoresListQueryHandler(IAppDbContext context)
    {
        _context = context;
    }

    public async Task<Result<List<ProfesorDTO>>> Handle(GetProfesoresListQuery request, CancellationToken cancellationToken)
    {
        var profesores = await _context.Profesores // Nota: si en tu IAppDbContext se llama 'Profesores' en plural, ajústalo aquí.
            .Select(p => new ProfesorDTO
            {
                Id = p.Id,
                Identificacion = p.Identificacion,
                NombreCompleto = $"{p.Nombres} {p.Apellidos}",
                Correo = p.Correo,
                Departamento = p.Departamento
            })
            .ToListAsync(cancellationToken);

        return Result<List<ProfesorDTO>>.Success(profesores);
    }
}