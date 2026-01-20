using Notenverwaltung.Shared.Dtos.CourseDtos;
using System.Net.Http.Json;

namespace Notenverwaltung.Web.Services;

public class CourseService
{
    private readonly HttpClient _httpClient;
    public CourseService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<HttpResponseMessage> GetCoursesAsync()
    {
        HttpResponseMessage response = await _httpClient.GetAsync("api/Course/getCourses");
        return response;
    }
}
