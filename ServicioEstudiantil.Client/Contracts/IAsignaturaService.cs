using ServicioEstudiantil.Core.DTOs;

namespace ServicioEstudiantil.Client.Contracts;

public interface IAsignaturaService
{
    Task<List<AsignaturaDTO>?> ObtenerAsignaturasAsync();
    Task<bool> CrearAsignaturaAsync(object command);
    Task<bool> ActualizarAsignaturaAsync(int id, object command);
    Task<bool> EliminarAsignaturaAsync(int id);
}