using ServicioEstudiantil.Client.Contracts;
using ServicioEstudiantil.Client.Extensions;
using ServicioEstudiantil.Core.DTOs;

namespace ServicioEstudiantil.Client.Services
{
    public class TitulacionService : ITitulacionService
    {
        private readonly HttpClientService _httpService;

        public TitulacionService(HttpClientService httpService)
        {
            _httpService = httpService;
        }

        public async Task<List<TitulacionDTO>?> ObtenerTitulacionesAsync()
        {
            return await _httpService.GetAsync<List<TitulacionDTO>>("titulaciones");
        }

        public async Task<TitulacionDTO?> ObtenerTitulacionPorIdAsync(int id)
        {
            return await _httpService.GetAsync<TitulacionDTO>($"titulaciones/{id}");
        }
    }
}