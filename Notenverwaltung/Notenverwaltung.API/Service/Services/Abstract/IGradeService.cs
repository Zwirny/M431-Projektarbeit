using Notenverwaltung.API.DataAccess.Models;
using Notenverwaltung.API.DataAccess.Repositories.Abstract;
using Notenverwaltung.Shared.Dtos.GradeDtos;

namespace Notenverwaltung.API.Service.Services.Abstract
{
    public interface IGradeService
    {
        void PostGrade(PostGradeDto dto, int UserId);

        int PutGradeById(int id, PutGradeDto dto);

        Grade GetGradeById(int id);

        int DeleteGradeById(int id);

        List<Grade> GetGrades();

    }
}
