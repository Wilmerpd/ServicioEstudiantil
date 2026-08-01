using ServicioEstudiantil.Core.DTOs;

namespace ServicioEstudiantil.Client.Contracts
{
    public interface IEstudianteService
    {
        Task<List<EstudianteDTO>?> ObtenerEstudiantesAsync();
        Task<EstudianteDTO?> ObtenerEstudiantePorIdAsync(int id);

        // LOS 3 MÉTODOS QUE SAUL ESTÁ ESPERANDO:
        Task<bool> CrearEstudianteAsync(EstudianteDTO estudiante);
        Task<bool> ActualizarEstudianteAsync(EstudianteDTO estudiante);
        Task<bool> EliminarEstudianteAsync(int id);
    }
}