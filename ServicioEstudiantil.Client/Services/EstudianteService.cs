using System.Net.Http.Json;
using ServicioEstudiantil.Client.Contracts;
using ServicioEstudiantil.Core.Features.Estudiantes.Queries.GetEstudiantesList;

namespace ServicioEstudiantil.Client.Services;

public class EstudianteService : IEstudianteService
{
    private readonly HttpClient _http;

    public EstudianteService(HttpClient http)
    {
        _http = http;
    }

    public async Task<List<EstudianteDto>?> ObtenerEstudiantesAsync()
    {
        try
        {
            return await _http.GetFromJsonAsync<List<EstudianteDto>>("api/Estudiantes");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
            return null;
        }
    }

    public async Task<EstudianteDto?> ObtenerEstudiantePorIdAsync(int id)
    {
        try
        {
            return await _http.GetFromJsonAsync<EstudianteDto>($"api/Estudiantes/{id}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
            return null;
        }
    }

    public async Task<bool> CrearEstudianteAsync(object command)
    {
        var response = await _http.PostAsJsonAsync("api/Estudiantes", command);
        return response.IsSuccessStatusCode;
    }

    public async Task<bool> ActualizarEstudianteAsync(int id, object command)
    {
        var response = await _http.PutAsJsonAsync($"api/Estudiantes/{id}", command);
        return response.IsSuccessStatusCode;
    }

    public async Task<bool> EliminarEstudianteAsync(int id)
    {
        var response = await _http.DeleteAsync($"api/Estudiantes/{id}");
        return response.IsSuccessStatusCode;
    }
}