using Notenverwaltung.Shared.Dtos.UserDtos;

namespace Notenverwaltung.Web.Services.Abstract;

public interface IAuthService
{
    Task<AuthResponse?> RegisterAsync(RegisterDto registerModel);
    Task<AuthResponse?> LoginAsync(LoginDto registerModel);
}
