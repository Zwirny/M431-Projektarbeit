using Notenverwaltung.API.DataAccess.Models;
using Notenverwaltung.API.DataAccess.Repositories.Abstract;
using Notenverwaltung.Shared.Dtos.GradeDtos;

namespace Notenverwaltung.API.Service.Services.Abstract
{
    public interface IGradeService
    {
        void PostGrade(PostGradeDto dto, int UserId);
    }
}
