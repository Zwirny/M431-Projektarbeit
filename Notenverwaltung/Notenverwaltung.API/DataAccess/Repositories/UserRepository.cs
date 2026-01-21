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
            User user = _db.Users.FirstOrDefault(u => u.Email == dto.Email && dto.Passwort == u.Passwort);
            if (user == null)
            {
                return null;
            }
            return user;
        }

        public void Register(User user)
        {
            _db.Users.Add(user);
            _db.SaveChanges();
        } 
    }
}
