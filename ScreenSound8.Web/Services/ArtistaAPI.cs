using ScreenSound8.Web.Requests;
using ScreenSound8.Web.Response;
using System.Net.Http;
using System.Net.Http.Json;

namespace ScreenSound8.Web.Services
{
    public class ArtistaAPI
    {
        private readonly HttpClient _httpClient;

        public ArtistaAPI(IHttpClientFactory factory)
        {
            _httpClient = factory.CreateClient("API");
        }
        public async Task<ICollection<ArtistaResponse>?> GetArtistasAsync()
        {
            return await
            _httpClient.GetFromJsonAsync<ICollection<ArtistaResponse>>("Artistas");
        }
        public async Task AddArtistaAsync (ArtistaRequest request)
        {
            await _httpClient.PostAsJsonAsync("Artistas", request);
        }
        public async Task DeleteArtistaAsync(int id)
        {
            await _httpClient.DeleteAsync($"Artistas/{id}");
        }
        public async Task UpdateArtistaAsync(ArtistaRequestEdit artista) 
        {
            await _httpClient.PutAsJsonAsync($"Artistas", artista);
        }
        public async Task<ArtistaResponse?> GetArtistaPorNomeAsync(string nome)
        {
            return await _httpClient.GetFromJsonAsync<ArtistaResponse>($"Artistas/{nome}");
        }
    }
}
