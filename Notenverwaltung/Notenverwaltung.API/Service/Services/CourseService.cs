using Notenverwaltung.API.DataAccess.Models;
using Notenverwaltung.API.DataAccess.Repositories;
using Notenverwaltung.API.DataAccess.Repositories.Abstract;
using Notenverwaltung.API.Service.Services.Abstract;

namespace Notenverwaltung.API.Service.Services
{
    public class CourseService : ICourseService
    {
        ICourseRepository _courseRepository;
        public CourseService(ICourseRepository courseRepository)
        {
            _courseRepository = courseRepository;
        }
        public Course GetCourseById(int id)
        {
            var course = _courseRepository.GetCourseById(id);
            if (course == null)
            {
                return null;
            }
            
            return course;
        }

        public List<Course> GetCourses()
        {
            var result = _courseRepository.GetCourses().ToList();
            if (result == null)
            {
                return null;
            }
            return result;
        }
    }
}
