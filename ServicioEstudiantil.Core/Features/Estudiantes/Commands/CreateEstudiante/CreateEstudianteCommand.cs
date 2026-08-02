using MediatR;
using ServicioEstudiantil.Core.Common;
using ServicioEstudiantil.Core.Entities;

namespace ServicioEstudiantil.Core.Features.Estudiantes.Commands.CreateEstudiante;

// 1. El Comando con los datos que necesitamos para registrar al estudiante
public record CreateEstudianteCommand(
    string Matricula,
    string Nombres,
    string Apellidos,
    string CorreoInstitucional,
    int TitulacionId
) : IRequest<Result<int>>; // Devuelve el ID del estudiante creado si es exitoso

// 2. El Manejador (Handler) que procesa la lógica e inserta en la BD
public class CreateEstudianteCommandHandler : IRequestHandler<CreateEstudianteCommand, Result<int>>
{
    private readonly IAppDbContext _context;

    public CreateEstudianteCommandHandler(IAppDbContext context)
    {
        _context = context;
    }

    public async Task<Result<int>> Handle(CreateEstudianteCommand request, CancellationToken cancellationToken)
    {
        // Validación básica de negocio
        if (string.IsNullOrWhiteSpace(request.Matricula))
        {
            return Result<int>.Failure("La matrícula es obligatoria.");
        }

        // Creamos la entidad
        var nuevoEstudiante = new Estudiante
        {
            Matricula = request.Matricula,
            Nombres = request.Nombres,
            Apellidos = request.Apellidos,
            CorreoInstitucional = request.CorreoInstitucional,
            TitulacionId = request.TitulacionId,
            EstaActivo = true
        };

        // Guardamos en la base de datos a través de la interfaz
        _context.Estudiantes.Add(nuevoEstudiante);
        await _context.SaveChangesAsync(cancellationToken);

        return Result<int>.Success(nuevoEstudiante.Id);
    }
}