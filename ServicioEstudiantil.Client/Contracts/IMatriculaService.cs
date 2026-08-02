using ServicioEstudiantil.Core.DTOs;

namespace ServicioEstudiantil.Client.Contracts;

public interface IMatriculaService
{
    Task<List<MatriculaDTO>?> ObtenerMatriculasAsync();
    Task<bool> CrearMatriculaAsync(object command);
    Task<bool> EliminarMatriculaAsync(int id);
}