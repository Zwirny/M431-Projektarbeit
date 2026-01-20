using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using Notenverwaltung.API.DataAccess.Models;
using Notenverwaltung.API.DataAccess.Repositories.Abstract;
using Notenverwaltung.API.Service.Services.Abstract;
using Notenverwaltung.Shared.Dtos.UserDtos;

namespace Notenverwaltung.API.Service.Services
{
    public class AuthService : IAuthService
    {
        IUserRepository _userRepository;
        IConfiguration _configuration;
        public AuthService(IUserRepository UserReoisutory, IConfiguration configuration)
        {
            _userRepository = UserReoisutory;
            _configuration = configuration;
        }
        public AuthReciveDto Login(LoginDto dto)
        {
            User user = _userRepository.Login(dto);
            if (user == null)
            {
                return null;
            }
            string token = GenerateJwtToken(user);
            
            return new AuthReciveDto { Token = token };
        }
        public AuthReciveDto Register(RegisterDto dto)
        {
            if (dto.Vorname == null || dto.Nachname == null ||
                dto.Email == null || dto.Passwort == null)
            {
                return null;
            }

            User user = new User
            {
                Email = dto.Email,
                Vorname = dto.Vorname,
                Nachname = dto.Nachname,
                Passwort = dto.Passwort,
                StatusId = 2
            };
            string token = GenerateJwtToken(user);
            _userRepository.Register(user);
            return new AuthReciveDto { Token = token };

        }

        private string GenerateJwtToken(User user)
        {
            JwtSecurityTokenHandler tokenHandler = new
                JwtSecurityTokenHandler();


            byte[] key = Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]);

            Claim[] claims = new[]
            {
                new Claim("UserId", user.Id.ToString()),
                new Claim("StatusID", user.StatusId.ToString()),
                new Claim(JwtRegisteredClaimNames.Email, user.Email),
                new Claim(JwtRegisteredClaimNames.GivenName, user.Vorname),
            };

            SecurityTokenDescriptor tokenDescriptor = new
                SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.UtcNow.AddHours(2),
                Issuer = _configuration["Jwt:Issuer"],
                Audience = _configuration["Jwt:Audience"],
                SigningCredentials = new SigningCredentials(
                    new SymmetricSecurityKey(key),
                    SecurityAlgorithms.HmacSha256Signature
                )
            };

            SecurityToken token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
    }
}
