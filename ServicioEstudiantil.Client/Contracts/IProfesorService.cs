using ServicioEstudiantil.Core.DTOs;

namespace ServicioEstudiantil.Client.Contracts
{
    public interface IProfesorService
    {
        Task<List<ProfesorDTO>?> ObtenerProfesoresAsync();
        Task<ProfesorDTO?> ObtenerProfesorPorIdAsync(int id);
    }
}