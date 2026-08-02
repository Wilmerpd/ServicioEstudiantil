using MediatR;
using ServicioEstudiantil.Core.Common;

namespace ServicioEstudiantil.Core.Features.Estudiantes.Queries.GetEstudianteById;

// 1. La consulta (Query) que transporta el ID solicitado
public record GetEstudianteByIdQuery(int Id) : IRequest<Result<EstudianteDto>>;

// 2. El DTO de transferencia limpio para la respuesta
public record EstudianteDto(int Id, string Nombre, string Correo, string Matricula);

// 3. El manejador (Handler) que ejecuta la lógica de negocio
public class GetEstudianteByIdQueryHandler : IRequestHandler<GetEstudianteByIdQuery, Result<EstudianteDto>>
{
    // Más adelante aquí inyectaremos tu ApplicationDbContext para buscar en la base de datos real

    public async Task<Result<EstudianteDto>> Handle(GetEstudianteByIdQuery request, CancellationToken cancellationToken)
    {
        if (request.Id <= 0)
        {
            return Result<EstudianteDto>.Failure("El ID del estudiante no es válido.");
        }

        // Datos de prueba (mock) mientras conectamos el repositorio/DbContext
        var estudianteDto = new EstudianteDto(request.Id, "Wilmer Peña", "wilmer@email.com", "2024-0001");

        return Result<EstudianteDto>.Success(estudianteDto);
    }
}