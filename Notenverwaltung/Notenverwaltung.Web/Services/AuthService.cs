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

        public async Task<AuthResponse?> RegisterAsync(LoginRequestDTO registerModel)
        {
            var response = await _httpClient.PostAsJsonAsync("api/Authentication/register", registerModel);

            if (response.IsSuccessStatusCode)
            {
                return await
                     response.Content.ReadFromJsonAsync<AuthResponse>();
            }
            return null;
        }
        public async Task<AuthResponse?> LoginAsync(LoginRequestDTO loginModel)
        {
            var response = await _httpClient.PostAsJsonAsync("api/Authentication/login", loginModel);

            if (response.IsSuccessStatusCode)
            {
                return await
                     response.Content.ReadFromJsonAsync<AuthResponse>();
            }
            return null;
        }
    }
}
