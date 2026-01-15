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
    }
}
