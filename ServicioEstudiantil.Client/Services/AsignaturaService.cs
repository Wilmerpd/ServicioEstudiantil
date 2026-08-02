using System.Net.Http.Json;
using ServicioEstudiantil.Client.Contracts;
using ServicioEstudiantil.Core.DTOs;

namespace ServicioEstudiantil.Client.Services;

public class AsignaturaService : IAsignaturaService
{
    private readonly HttpClient _http;

    public AsignaturaService(HttpClient http)
    {
        _http = http;
    }

    public async Task<List<AsignaturaDTO>?> ObtenerAsignaturasAsync()
    {
        try
        {
            return await _http.GetFromJsonAsync<List<AsignaturaDTO>>("api/Asignaturas");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
            return null;
        }
    }

    public async Task<bool> CrearAsignaturaAsync(object command)
    {
        var response = await _http.PostAsJsonAsync("api/Asignaturas", command);
        return response.IsSuccessStatusCode;
    }

    public async Task<bool> ActualizarAsignaturaAsync(int id, object command)
    {
        var response = await _http.PutAsJsonAsync($"api/Asignaturas/{id}", command);
        return response.IsSuccessStatusCode;
    }

    public async Task<bool> EliminarAsignaturaAsync(int id)
    {
        var response = await _http.DeleteAsync($"api/Asignaturas/{id}");
        return response.IsSuccessStatusCode;
    }
}