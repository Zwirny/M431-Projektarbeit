using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Notenverwaltung.API.Service.Services.Abstract;
using Notenverwaltung.Shared.Dtos.GradeDtos;

namespace Notenverwaltung.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class GradeControllers : ControllerBase
{
    IGradeService _gradeService;

    public GradeControllers(IGradeService service)
    {
        _gradeService = service;
    }

    [HttpPost("postGrade")]
    [Authorize]
    public IActionResult PostGrade(PostGradeDto dto)
    {
        int userIdClaim = int.Parse(User.Claims.FirstOrDefault(c => c.Type == "UserId").Value);

        if (userIdClaim == null)
        {
            return Unauthorized();
        }
        _gradeService.PostGrade(dto, userIdClaim);
        return Ok();
    }
}