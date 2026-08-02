using ServicioEstudiantil.Core.Features.Estudiantes.Queries.GetEstudiantesList;

namespace ServicioEstudiantil.Client.Contracts;

public interface IEstudianteService
{
    Task<List<EstudianteDto>?> ObtenerEstudiantesAsync();
    Task<EstudianteDto?> ObtenerEstudiantePorIdAsync(int id);
    Task<bool> CrearEstudianteAsync(object command);
    Task<bool> ActualizarEstudianteAsync(int id, object command);
    Task<bool> EliminarEstudianteAsync(int id);
}