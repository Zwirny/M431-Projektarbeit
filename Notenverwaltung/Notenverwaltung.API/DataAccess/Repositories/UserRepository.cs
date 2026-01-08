using Microsoft.AspNetCore.Components.Forms;
using Notenverwaltung.API.DataAccess.Models;
using Notenverwaltung.API.DataAccess.Repositories.Abstract;
using Notenverwaltung.Shared.Dtos.UserDtos;

namespace Notenverwaltung.API.DataAccess.Repositories
{
    public class UserRepository : IUserRepository
    {
        DBContext _db;
        public UserRepository(DBContext db)
        {
            _db = db;
        }

        public User Login(LoginDto dto)
        {
            return _db.Users.FirstOrDefault(u => u.Email == dto.Email && u.Passwort == u.Passwort);
        }

        public void Register(User user)
        {
            _db.Users.Add(user);
            _db.SaveChanges();
        } 
    }
}
