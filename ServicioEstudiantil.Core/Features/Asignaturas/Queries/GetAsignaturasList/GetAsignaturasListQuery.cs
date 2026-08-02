using MediatR;
using Microsoft.EntityFrameworkCore;
using ServicioEstudiantil.Core.Common;
using ServicioEstudiantil.Core.DTOs;

namespace ServicioEstudiantil.Core.Features.Asignaturas.Queries.GetAsignaturasList;

public record GetAsignaturasListQuery : IRequest<Result<List<AsignaturaDTO>>>;

public class GetAsignaturasListQueryHandler : IRequestHandler<GetAsignaturasListQuery, Result<List<AsignaturaDTO>>>
{
    private readonly IAppDbContext _context;

    public GetAsignaturasListQueryHandler(IAppDbContext context)
    {
        _context = context;
    }

    public async Task<Result<List<AsignaturaDTO>>> Handle(GetAsignaturasListQuery request, CancellationToken cancellationToken)
    {
        var asignaturas = await _context.Asignaturas
            .Select(a => new AsignaturaDTO
            {
                Id = a.Id,
                Codigo = a.Codigo,
                Nombre = a.Nombre,
                Creditos = a.Creditos,
                Departamento = a.Departamento
            })
            .ToListAsync(cancellationToken);

        return Result<List<AsignaturaDTO>>.Success(asignaturas);
    }
}