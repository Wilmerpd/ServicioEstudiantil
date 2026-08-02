using System.Net.Http.Json;
using ServicioEstudiantil.Client.Contracts;
using ServicioEstudiantil.Core.DTOs;

namespace ServicioEstudiantil.Client.Services;

public class MatriculaService : IMatriculaService
{
    private readonly HttpClient _http;

    public MatriculaService(HttpClient http)
    {
        _http = http;
    }

    public async Task<List<MatriculaDTO>?> ObtenerMatriculasAsync()
    {
        try
        {
            return await _http.GetFromJsonAsync<List<MatriculaDTO>>("api/Matriculas");
        }
        catch (Exception)
        {
            return null;
        }
    }

    public async Task<bool> CrearMatriculaAsync(object command)
    {
        var response = await _http.PostAsJsonAsync("api/Matriculas", command);
        return response.IsSuccessStatusCode;
    }

    public async Task<bool> EliminarMatriculaAsync(int id)
    {
        var response = await _http.DeleteAsync($"api/Matriculas/{id}");
        return response.IsSuccessStatusCode;
    }
}