using System.Net.Http.Json;
using ServicioEstudiantil.Client.Contracts;
using ServicioEstudiantil.Core.DTOs;

namespace ServicioEstudiantil.Client.Services;

public class CalificacionService : ICalificacionService
{
    private readonly HttpClient _http;

    public CalificacionService(HttpClient http)
    {
        _http = http;
    }

    public async Task<List<CalificacionDTO>?> ObtenerCalificacionesAsync()
    {
        try
        {
            return await _http.GetFromJsonAsync<List<CalificacionDTO>>("api/Calificaciones");
        }
        catch (Exception)
        {
            return null;
        }
    }

    public async Task<bool> CrearCalificacionAsync(object command)
    {
        var response = await _http.PostAsJsonAsync("api/Calificaciones", command);
        return response.IsSuccessStatusCode;
    }

    public async Task<bool> EliminarCalificacionAsync(int id)
    {
        var response = await _http.DeleteAsync($"api/Calificaciones/{id}");
        return response.IsSuccessStatusCode;
    }
}