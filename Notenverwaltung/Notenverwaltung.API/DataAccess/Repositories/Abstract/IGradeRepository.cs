using Notenverwaltung.API.DataAccess.Models;

namespace Notenverwaltung.API.DataAccess.Repositories.Abstract
{
    public interface IGradeRepository
    {
        void PostGrade(Grade grade);
    }
}
