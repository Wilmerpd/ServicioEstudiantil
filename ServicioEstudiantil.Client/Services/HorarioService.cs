using ServicioEstudiantil.Client.Contracts;
using ServicioEstudiantil.Client.Extensions;
using ServicioEstudiantil.Core.DTOs;

namespace ServicioEstudiantil.Client.Services
{
    public class HorarioService : IHorarioService
    {
        private readonly HttpClientService _httpService;

        public HorarioService(HttpClientService httpService)
        {
            _httpService = httpService;
        }

        public async Task<List<HorarioDTO>?> ObtenerHorariosAsync()
        {
            return await _httpService.GetAsync<List<HorarioDTO>>("horarios");
        }

        public async Task<HorarioDTO?> ObtenerHorarioPorIdAsync(int id)
        {
            return await _httpService.GetAsync<HorarioDTO>($"horarios/{id}");
        }
    }
}