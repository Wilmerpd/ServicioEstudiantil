using ServicioEstudiantil.Core.DTOs;

namespace ServicioEstudiantil.Client.Contracts
{
    public interface IHorarioService
    {
        Task<List<HorarioDTO>?> ObtenerHorariosAsync();
        Task<HorarioDTO?> ObtenerHorarioPorIdAsync(int id);
        Task<bool> CrearHorarioAsync(HorarioInputDTO horario);
        Task<bool> ActualizarHorarioAsync(HorarioInputDTO horario);
        Task<bool> EliminarHorarioAsync(int id);
    }
}