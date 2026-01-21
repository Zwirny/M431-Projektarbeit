using Notenverwaltung.Shared.Dtos.CourseDtos;

namespace Notenverwaltung.Web.Services.Abstract;

public interface ICourseService
{
    Task<List<CourseDto>> GetCoursesAsync();
}
