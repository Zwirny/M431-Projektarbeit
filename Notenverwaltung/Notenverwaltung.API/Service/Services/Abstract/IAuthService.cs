using Notenverwaltung.Shared.Dtos.UserDtos;

namespace Notenverwaltung.API.Service.Services.Abstract;

public interface IAuthService
{
    AuthReciveDto Login(LoginDto dto);
    AuthReciveDto Register(RegisterDto dto);

}
