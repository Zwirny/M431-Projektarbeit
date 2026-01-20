using Notenverwaltung.Shared.Dtos.GradeDtos;

namespace Notenverwaltung.Web.Services.Abstract;

public interface IGradeService
{
    Task<HttpResponseMessage> PostGradeAsync(PostGradeDto postGradeModel);
}
