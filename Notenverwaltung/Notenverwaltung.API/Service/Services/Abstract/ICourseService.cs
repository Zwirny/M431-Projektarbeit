using Notenverwaltung.API.DataAccess.Models;

namespace Notenverwaltung.API.Service.Services.Abstract
{
    public interface ICourseService
    {
        Course GetCourseById(int id);
    }
}
