using ServicioEstudiantil.Client.Contracts;
using ServicioEstudiantil.Client.Extensions;
using ServicioEstudiantil.Core.DTOs;

namespace ServicioEstudiantil.Client.Services
{
    public class EstudianteService : IEstudianteService
    {
        private readonly HttpClientService _httpService;

        public EstudianteService(HttpClientService httpService)
        {
            _httpService = httpService;
        }

        public async Task<List<EstudianteDTO>?> ObtenerEstudiantesAsync()
        {
            return await _httpService.GetAsync<List<EstudianteDTO>>("estudiantes");
        }

        public async Task<EstudianteDTO?> ObtenerEstudiantePorIdAsync(int id)
        {
            return await _httpService.GetAsync<EstudianteDTO>($"estudiantes/{id}");
        }
        // (Debajo de tus métodos Obtener...)

        public async Task<bool> CrearEstudianteAsync(EstudianteDTO estudiante)
        {
            var response = await _httpService.PostAsync<EstudianteDTO>("estudiantes", estudiante);
            return response != null;
        }

        public async Task<bool> ActualizarEstudianteAsync(EstudianteDTO estudiante)
        {
            var response = await _httpService.PutAsync<EstudianteDTO>($"estudiantes/{estudiante.Id}", estudiante);
            return true;
        }

        public async Task<bool> EliminarEstudianteAsync(int id)
        {
            var response = await _httpService.DeleteAsync<bool>($"estudiantes/{id}");
            return true;
        }
    }
}