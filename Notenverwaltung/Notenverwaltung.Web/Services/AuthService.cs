using Notenverwaltung.Shared.Dtos.UserDtos;
using Notenverwaltung.Web.Services.Abstract;
using System.Net.Http.Json;

namespace Notenverwaltung.Web.Services
{
    public class AuthService : IAuthService
    {
        private readonly HttpClient _httpClient;
        public AuthService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<AuthResponse?> RegisterAsync(RegisterDto registerModel)
        {
            HttpResponseMessage response = await _httpClient.PostAsJsonAsync("api/Auth/register", registerModel);

            if (response.IsSuccessStatusCode)
                return await response.Content.ReadFromJsonAsync<AuthResponse>();

            // Optional: throw a helpful error (recommended)
            var msg = await response.Content.ReadAsStringAsync();
            throw new Exception(string.IsNullOrWhiteSpace(msg)
                ? $"Register failed ({(int)response.StatusCode})"
                : msg);
        }
        public async Task<AuthResponse?> LoginAsync(LoginDto loginModel)
        {
            HttpResponseMessage response = await _httpClient.PostAsJsonAsync("api/Auth/login", loginModel);

            if (response.IsSuccessStatusCode)
            {
                return await
                     response.Content.ReadFromJsonAsync<AuthResponse>();
            }
            return null;
        }
    }
}
