using ServicioEstudiantil.Client.Contracts;
using ServicioEstudiantil.Client.Extensions;
using ServicioEstudiantil.Core.DTOs;

namespace ServicioEstudiantil.Client.Services
{
    public class AsignaturaService : IAsignaturaService
    {
        private readonly HttpClientService _httpService;

        public AsignaturaService(HttpClientService httpService)
        {
            _httpService = httpService;
        }

        public async Task<List<AsignaturaDTO>?> ObtenerAsignaturasAsync()
        {
            return await _httpService.GetAsync<List<AsignaturaDTO>>("asignaturas");
        }

        public async Task<AsignaturaDTO?> ObtenerAsignaturaPorIdAsync(int id)
        {
            return await _httpService.GetAsync<AsignaturaDTO>($"asignaturas/{id}");
        }
        public async Task<bool> CrearAsignaturaAsync(AsignaturaInputDTO asignatura)
        {
            var response = await _httpService.PostAsync<AsignaturaInputDTO>("asignaturas", asignatura);
            return response != null;
        }

        public async Task<bool> ActualizarAsignaturaAsync(AsignaturaInputDTO asignatura)
        {
            var response = await _httpService.PutAsync<AsignaturaInputDTO>($"asignaturas/{asignatura.Id}", asignatura);
            return true;
        }

        public async Task<bool> EliminarAsignaturaAsync(int id)
        {
            var response = await _httpService.DeleteAsync<bool>($"asignaturas/{id}");
            return true;
        }
    }
}