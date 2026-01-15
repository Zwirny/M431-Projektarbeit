using Notenverwaltung.API.DataAccess.Models;
using Notenverwaltung.API.DataAccess.Repositories.Abstract;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace Notenverwaltung.API.DataAccess.Repositories
{
    public class GradeRepository : IGradeRepository
    {
        DBContext _db;
        public GradeRepository(DBContext db)
        {
            _db = db;
        }

        public Grade GetGradeById(int id)
        {
            Grade result = _db.Grades.Find(id);
            return result;
        }

        public void PostGrade(Grade grade)
        {
            _db.Grades.Add(grade);
            _db.SaveChanges();
        }

        public void PutGrade(int id, Grade grade)
        {
            var gradeById = _db.Grades.FirstOrDefault(g => g.Id == id);
            if (gradeById == null) return;

            gradeById.LehrpersonID = grade.LehrpersonID;
            gradeById.KursID = grade.KursID;
            gradeById.SchuelerVorname = grade.SchuelerVorname;
            gradeById.SchuelerNachname = grade.SchuelerNachname;
            gradeById.Note = grade.Note;
            gradeById.Bemerkung = grade.Bemerkung;

            _db.Grades.Update(gradeById);
            _db.SaveChanges();
        }

        public void DeleteGradeById(int id)
        {
            var gradeById = _db.Grades.FirstOrDefault(g => g.Id == id);
            if (gradeById == null) return;
            _db.Grades.Remove(gradeById);
            _db.SaveChanges();
        }

        public IEnumerable<Grade> GetGrades()
        {
            return _db.Grades;
        }
    }
}
