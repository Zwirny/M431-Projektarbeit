using Notenverwaltung.API.DataAccess.Models;

namespace Notenverwaltung.API.DataAccess.Repositories.Abstract
{
    public interface ICourseRepository
    {
        Course GetCourseById(int id);
    }
}
