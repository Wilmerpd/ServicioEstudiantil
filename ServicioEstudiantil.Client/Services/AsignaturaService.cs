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
    }
}