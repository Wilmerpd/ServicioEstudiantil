using MediatR;
using ServicioEstudiantil.Core.Common;

namespace ServicioEstudiantil.Core.Features.Estudiantes.Commands.DeleteEstudiante;

public record DeleteEstudianteCommand(int Id) : IRequest<Result<bool>>;

public class DeleteEstudianteCommandHandler : IRequestHandler<DeleteEstudianteCommand, Result<bool>>
{
    private readonly IAppDbContext _context;

    public DeleteEstudianteCommandHandler(IAppDbContext context)
    {
        _context = context;
    }

    public async Task<Result<bool>> Handle(DeleteEstudianteCommand request, CancellationToken cancellationToken)
    {
        var estudiante = await _context.Estudiantes.FindAsync(new object[] { request.Id }, cancellationToken);

        if (estudiante == null)
        {
            return Result<bool>.Failure("El estudiante especificado no fue encontrado.");
        }

        _context.Estudiantes.Remove(estudiante);
        await _context.SaveChangesAsync(cancellationToken);

        return Result<bool>.Success(true);
    }
}