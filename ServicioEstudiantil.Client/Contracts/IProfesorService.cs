using ServicioEstudiantil.Core.DTOs;

namespace ServicioEstudiantil.Client.Contracts
{
    public interface IProfesorService
    {
        Task<List<ProfesorDTO>?> ObtenerProfesoresAsync();
        Task<ProfesorDTO?> ObtenerProfesorPorIdAsync(int id);
        Task<bool> CrearProfesorAsync(ProfesorInputDTO profesor);
        Task<bool> ActualizarProfesorAsync(ProfesorInputDTO profesor);
        Task<bool> EliminarProfesorAsync(int id);
    }
}