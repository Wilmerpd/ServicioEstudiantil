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
    }
}