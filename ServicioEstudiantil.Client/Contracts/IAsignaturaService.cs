using ServicioEstudiantil.Core.DTOs;

namespace ServicioEstudiantil.Client.Contracts
{
    public interface IAsignaturaService
    {
        Task<List<AsignaturaDTO>?> ObtenerAsignaturasAsync();
        Task<AsignaturaDTO?> ObtenerAsignaturaPorIdAsync(int id);
        Task<bool> CrearAsignaturaAsync(AsignaturaInputDTO asignatura);
        Task<bool> ActualizarAsignaturaAsync(AsignaturaInputDTO asignatura);
        Task<bool> EliminarAsignaturaAsync(int id);
    }
}