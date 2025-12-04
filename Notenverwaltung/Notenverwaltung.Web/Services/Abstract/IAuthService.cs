namespace Notenverwaltung.Web.Services.Abstract;

public interface IAuthService
{
    Task<AuthResponse?> RegisterAsync(LoginRequestDTO registerModel);
    Task<AuthResponse?> LoginAsync(LoginRequestDTO registerModel);
}
