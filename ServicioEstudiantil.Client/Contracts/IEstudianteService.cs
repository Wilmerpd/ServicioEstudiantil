using ServicioEstudiantil.Core.DTOs;

namespace ServicioEstudiantil.Client.Contracts
{
    public interface IEstudianteService
    {
        Task<List<EstudianteDTO>?> ObtenerEstudiantesAsync();
        Task<EstudianteDTO?> ObtenerEstudiantePorIdAsync(int id);
    }
}