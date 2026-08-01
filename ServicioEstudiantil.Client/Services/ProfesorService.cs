using ServicioEstudiantil.Client.Contracts;
using ServicioEstudiantil.Client.Extensions;
using ServicioEstudiantil.Core.DTOs;

namespace ServicioEstudiantil.Client.Services
{
    public class ProfesorService : IProfesorService
    {
        private readonly HttpClientService _httpService;

        public ProfesorService(HttpClientService httpService)
        {
            _httpService = httpService;
        }

        public async Task<List<ProfesorDTO>?> ObtenerProfesoresAsync()
        {
            return await _httpService.GetAsync<List<ProfesorDTO>>("profesores");
        }

        public async Task<ProfesorDTO?> ObtenerProfesorPorIdAsync(int id)
        {
            return await _httpService.GetAsync<ProfesorDTO>($"profesores/{id}");
        }
        public async Task<bool> CrearProfesorAsync(ProfesorInputDTO profesor)
        {
            var response = await _httpService.PostAsync<ProfesorInputDTO>("profesores", profesor);
            return response != null;
        }

        public async Task<bool> ActualizarProfesorAsync(ProfesorInputDTO profesor)
        {
            // Usamos el PutAsync que ya ajustamos en el HttpClientService
            var response = await _httpService.PutAsync<object>($"profesores/{profesor.Id}", profesor);

            // Si llegó hasta aquí sin romperse, la actualización fue exitosa
            return true;
        }

        public async Task<bool> EliminarProfesorAsync(int id)
        {
            var response = await _httpService.DeleteAsync<object>($"profesores/{id}");

            // Si la petición se completó, devolvemos true para que la interfaz limpie y recargue
            return true;
        }
    }
}