using Notenverwaltung.API.DataAccess.Models;
using Notenverwaltung.API.DataAccess.Repositories.Abstract;

namespace Notenverwaltung.API.DataAccess.Repositories
{
    public class GradeRepository : IGradeRepository
    {
        DBContext _db;
        public GradeRepository(DBContext db)
        {
            _db = db;
        }

        public void PostGrade(Grade grade)
        {
            _db.Grades.Add(grade);
            _db.SaveChanges();
        }
    }
}
