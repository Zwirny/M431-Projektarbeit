using Notenverwaltung.Shared.Dtos.CourseDtos;
using Notenverwaltung.Web.Services.Abstract;
using System.Net.Http.Json;

namespace Notenverwaltung.Web.Services;

public class CourseService : ICourseService
{
    private readonly HttpClient _httpClient;
    public CourseService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<List<CourseDto>> GetCoursesAsync()
    {
        List<CourseDto> response = await _httpClient.GetFromJsonAsync<List<CourseDto>>("api/Course/getCourses");
        return response;
    }
}
