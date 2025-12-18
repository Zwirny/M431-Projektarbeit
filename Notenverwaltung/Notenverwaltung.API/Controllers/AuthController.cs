using Microsoft.AspNetCore.Mvc;
using Notenverwaltung.API.Service.Services.Abstract;
using Notenverwaltung.Shared.Dtos.UserDtos;

namespace Notenverwaltung.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        IAuthService _authService;

        public AuthController(IAuthService service)
        {
            _authService = service;
        }

        [HttpPost("login")]

        public ActionResult<AuthReciveDto> login([FromBody] LoginDto dto)
        {
            AuthReciveDto authDto = _authService.Login(dto);
            if (authDto == null)
            {
                return Unauthorized();
            }
            return Ok(authDto);
        }
        [HttpPost("register")]

        public ActionResult<AuthReciveDto> register([FromBody] RegisterDto dto)
        {
            AuthReciveDto authDto = _authService.Register(dto);
            if (authDto == null)
            {
                return Unauthorized();
            }
            return Ok(authDto);
        }

    }
}
