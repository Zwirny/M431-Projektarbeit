using Notenverwaltung.Shared.Dtos.GradeDtos;
using Notenverwaltung.Web.Services.Abstract;
using System.Net.Http.Json;

namespace Notenverwaltung.Web.Services;

public class GradeService : IGradeService
{
    private readonly HttpClient _httpClient;
    public GradeService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<HttpResponseMessage> PostGradeAsync(PostGradeDto postGradeModel)
    {
        HttpResponseMessage response = await _httpClient.PostAsJsonAsync("api/GradeControllers/postGrade", postGradeModel);
        return response;
    }
}
