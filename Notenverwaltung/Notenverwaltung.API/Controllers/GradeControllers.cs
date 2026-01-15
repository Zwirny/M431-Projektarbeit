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

    [HttpPut("putGrade")]
    [Authorize]
    public IActionResult PutGrade(int Id, PutGradeDto dto)
    {
        var result = _gradeService.PutGradeById(Id, dto);
        if (result == 1)
        {
            return NotFound();
        }
        return Ok();
    }

    [HttpGet("getById")]
    [Authorize]
    public IActionResult GetById(int Id)
    {
        var result = _gradeService.GetGradeById(Id);
        if (result == null)
        {
            return NotFound();
        }
        return Ok(result);
    }

    [HttpDelete("deleteById")]
    [Authorize]
    public IActionResult DeleteById(int Id)
    {
        var result = _gradeService.DeleteGradeById(Id);
        if (result == 1)
        {
            return NotFound();
        }
        return Ok(result);
    }

    [HttpGet("getGrades")]
    [Authorize]
    public IActionResult GetGrades()
    {
        var result = _gradeService.GetGrades();
        if (result == null)
        {
            return NotFound();
        }
        return Ok(result);
    }
}