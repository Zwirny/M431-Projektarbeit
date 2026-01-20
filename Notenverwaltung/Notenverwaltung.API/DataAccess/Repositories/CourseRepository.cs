using Notenverwaltung.API.DataAccess.Models;
using Notenverwaltung.API.DataAccess.Repositories.Abstract;

namespace Notenverwaltung.API.DataAccess.Repositories
{
    public class CourseRepository : ICourseRepository
    {
        DBContext _db;
        public CourseRepository(DBContext db)
        {
            _db = db;
        }

        public Course GetCourseById(int id)
        {
            Course result = _db.Courses.Find(id);
            return result;
        }

        public IEnumerable<Course> GetCourses()
        {
            return _db.Courses;
        }
    }
}
