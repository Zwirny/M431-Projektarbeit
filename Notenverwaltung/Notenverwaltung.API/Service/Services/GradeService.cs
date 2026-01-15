using Notenverwaltung.API.DataAccess.Models;
using Notenverwaltung.API.DataAccess.Repositories.Abstract;
using Notenverwaltung.API.Service.Services.Abstract;
using Notenverwaltung.Shared.Dtos.GradeDtos;

namespace Notenverwaltung.API.Service.Services
{
    public class GradeService : IGradeService
    {
        IGradeRepository _gradeRepository;
        public GradeService(IGradeRepository gradeRepository)
        {
            _gradeRepository = gradeRepository;
        }

        public int DeleteGradeById(int id)
        {
            var grade = _gradeRepository.GetGradeById(id);
            if (grade == null)
            {
                return 1;
            }
            _gradeRepository.DeleteGradeById(id);
            return 0;
        }

        public Grade GetGradeById(int id)
        {
            var result = _gradeRepository.GetGradeById(id);
            return result;
        }

        public void PostGrade(PostGradeDto dto, int UserId)
        {
            Grade grade = new Grade
            {
                LehrpersonID = UserId,
                Note = dto.Grade,
                Bemerkung = dto.Notice,
                SchuelerVorname = dto.StudentFirstName,
                SchuelerNachname = dto.StudentLastName,
                KursID = dto.CourseId
            };

            _gradeRepository.PostGrade(grade);
        }

        public int PutGradeById(int id, PutGradeDto dto)
        {
            Grade gradeToChange = _gradeRepository.GetGradeById(id);
            if (gradeToChange == null)
            {
                return 1;
            }
            Grade UpdatedGrade = new Grade
            {
                LehrpersonID = gradeToChange.LehrpersonID,
                Note = dto.Grade,
                Bemerkung = dto.Notice,
                SchuelerVorname = dto.StudentFirstName,
                SchuelerNachname = dto.StudentLastName,
                KursID = dto.CourseId
            };
            _gradeRepository.PutGrade(id, UpdatedGrade);
            return 0;
        }

        public List<Grade> GetGrades()
        {
            var result = _gradeRepository.GetGrades().ToList();
            if (result == null)
            {
                return null;
            }
            return result;
        }
    }
}
