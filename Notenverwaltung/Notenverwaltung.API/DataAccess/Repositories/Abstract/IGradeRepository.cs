using Notenverwaltung.API.DataAccess.Models;

namespace Notenverwaltung.API.DataAccess.Repositories.Abstract
{
    public interface IGradeRepository
    {
        void PostGrade(Grade grade);
        void PutGrade(int id, Grade grade);
        Grade GetGradeById(int id);
        void DeleteGradeById(int id);
        IEnumerable<Grade> GetGrades();
    }
}
