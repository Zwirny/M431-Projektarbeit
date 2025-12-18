using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using Notenverwaltung.Shared.Dtos.UserDtos;
using Notenverwaltung.Web.Services.Abstract;

namespace Notenverwaltung.Web.Pages
{
    public partial class Login
    {
        private LoginDto loginModel = new();
        private string? errorMessage;

        [Inject]
        public IJSRuntime JSRuntime { get; set; } = default!;

        [Inject]
        public IAuthService _authService { get; set; } = default!;

        private async Task HandleLogin()
        {
            
            var response = await _authService.LoginAsync(loginModel);

            if (response != null)
            {
                await JSRuntime.InvokeVoidAsync("localStorage.setItem", "jwtToken", response.Token);
            }
            else
            {
                errorMessage = "Login failed. Please check credentials.";
            }
        }
    }
}
