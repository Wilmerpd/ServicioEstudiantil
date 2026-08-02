using MediatR;
using ServicioEstudiantil.Core.Common;

namespace ServicioEstudiantil.Core.Features.Estudiantes.Commands.UpdateEstudiante;

public record UpdateEstudianteCommand(
    int Id,
    string Matricula,
    string Nombres,
    string Apellidos,
    string CorreoInstitucional,
    int TitulacionId
) : IRequest<Result<bool>>;

public class UpdateEstudianteCommandHandler : IRequestHandler<UpdateEstudianteCommand, Result<bool>>
{
    private readonly IAppDbContext _context;

    public UpdateEstudianteCommandHandler(IAppDbContext context)
    {
        _context = context;
    }

    public async Task<Result<bool>> Handle(UpdateEstudianteCommand request, CancellationToken cancellationToken)
    {
        var estudiante = await _context.Estudiantes.FindAsync(new object[] { request.Id }, cancellationToken);

        if (estudiante == null)
        {
            return Result<bool>.Failure("El estudiante especificado no fue encontrado.");
        }

        estudiante.Matricula = request.Matricula;
        estudiante.Nombres = request.Nombres;
        estudiante.Apellidos = request.Apellidos;
        estudiante.CorreoInstitucional = request.CorreoInstitucional;
        estudiante.TitulacionId = request.TitulacionId;

        await _context.SaveChangesAsync(cancellationToken);

        return Result<bool>.Success(true);
    }
}