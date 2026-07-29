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
    }
}