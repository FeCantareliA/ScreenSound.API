using ScreenSound8.Web.Response;
using System.Net.Http.Json;

namespace ScreenSound8.Web.Services
{
    public class MusicaAPI
    {
        private readonly HttpClient _httpClient;

        public MusicaAPI(IHttpClientFactory factory)
        {
            _httpClient = factory.CreateClient("API");
        }
        public async Task<ICollection<MusicaResponse>?> GetMusicaAsync()
        {
            return await _httpClient.GetFromJsonAsync<ICollection<MusicaResponse>>("Musicas");
        }
    }
}
