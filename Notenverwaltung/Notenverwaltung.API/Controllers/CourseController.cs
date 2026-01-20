using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Notenverwaltung.API.Service.Services;
using Notenverwaltung.API.Service.Services.Abstract;

namespace Notenverwaltung.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CourseController : ControllerBase
    {
        ICourseService _courseService;

        public CourseController(ICourseService service)
        {
            _courseService = service;
        }

        [HttpGet("getById")]
        [Authorize]
        public IActionResult GetById(int Id)
        {
            var result = _courseService.GetCourseById(Id);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }

    }
}
