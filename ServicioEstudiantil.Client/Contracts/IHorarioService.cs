using ServicioEstudiantil.Core.DTOs;

namespace ServicioEstudiantil.Client.Contracts
{
    public interface IHorarioService
    {
        Task<List<HorarioDTO>?> ObtenerHorariosAsync();
        Task<HorarioDTO?> ObtenerHorarioPorIdAsync(int id);
    }
}