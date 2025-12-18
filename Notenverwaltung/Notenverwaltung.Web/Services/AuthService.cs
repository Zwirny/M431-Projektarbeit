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
            var response = await _httpClient.PostAsJsonAsync("api/Auth/register", registerModel);

            if (response.IsSuccessStatusCode)
            {
                return await
                     response.Content.ReadFromJsonAsync<AuthResponse>();
            }
            return null;
        }
        public async Task<AuthResponse?> LoginAsync(LoginDto loginModel)
        {
            var response = await _httpClient.PostAsJsonAsync("api/Auth/login", loginModel);

            if (response.IsSuccessStatusCode)
            {
                return await
                     response.Content.ReadFromJsonAsync<AuthResponse>();
            }
            return null;
        }
    }
}
