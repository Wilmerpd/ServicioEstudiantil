using System.Net.Http.Json;

namespace ServicioEstudiantil.Client.Extensions
{
    public class HttpClientService
    {
        private readonly HttpClient _httpClient;

        public HttpClientService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<T?> GetAsync<T>(string endpoint)
        {
            return await _httpClient.GetFromJsonAsync<T>($"{MyConstant.BaseApiUrl}{endpoint}");
        }

        public async Task<HttpResponseMessage> PostAsync<T>(string endpoint, T data)
        {
            return await _httpClient.PostAsJsonAsync($"{MyConstant.BaseApiUrl}{endpoint}", data);
        }
        public async Task<T> PutAsync<T>(string endpoint, object data)
        {
            var response = await _httpClient.PutAsJsonAsync($"{MyConstant.BaseApiUrl}{endpoint}", data);
            if (response.IsSuccessStatusCode)
            {
                // Si el servidor no devuelve contenido (como 204 No Content), evitamos que falle
                if (response.StatusCode == System.Net.HttpStatusCode.NoContent)
                    return default;

                return await response.Content.ReadFromJsonAsync<T>();
            }
            return default;
        }

        public async Task<T> DeleteAsync<T>(string endpoint)
        {
            var response = await _httpClient.DeleteAsync($"{MyConstant.BaseApiUrl}{endpoint}");
            if (response.IsSuccessStatusCode)
            {
                if (response.StatusCode == System.Net.HttpStatusCode.NoContent)
                    return default;

                return await response.Content.ReadFromJsonAsync<T>();
            }
            return default;
        }
    }
}