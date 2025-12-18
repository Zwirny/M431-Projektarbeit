using Notenverwaltung.API.DataAccess.Models;
using Notenverwaltung.Shared.Dtos.UserDtos;

namespace Notenverwaltung.API.DataAccess.Repositories.Abstract;
public interface IUserRepository
{

    User Login(LoginDto dto);

    void Register(User user);
}
