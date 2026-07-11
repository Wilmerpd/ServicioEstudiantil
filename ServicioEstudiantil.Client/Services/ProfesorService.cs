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
    }
}