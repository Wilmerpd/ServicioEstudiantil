using ServicioEstudiantil.Core.DTOs;

namespace ServicioEstudiantil.Client.Contracts
{
    public interface ITitulacionService
    {
        Task<List<TitulacionDTO>?> ObtenerTitulacionesAsync();
        Task<TitulacionDTO?> ObtenerTitulacionPorIdAsync(int id);
    }
}