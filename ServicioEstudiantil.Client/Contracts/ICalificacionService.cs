using ServicioEstudiantil.Core.DTOs;

namespace ServicioEstudiantil.Client.Contracts;

public interface ICalificacionService
{
    Task<List<CalificacionDTO>?> ObtenerCalificacionesAsync();
    Task<bool> CrearCalificacionAsync(object command);
    Task<bool> EliminarCalificacionAsync(int id);
}