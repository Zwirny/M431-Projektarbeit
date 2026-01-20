using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using Notenverwaltung.Shared.Dtos.GradeDtos;
using Notenverwaltung.Web.Services.Abstract;

namespace Notenverwaltung.Web.Pages;

public partial class Verwaltung
{
    PostGradeDto postGradeModel = new PostGradeDto();
    public string student;
    public float examGrade;
    public string course;
    public string notice;

    [Inject]
    public IJSRuntime JSRuntime { get; set; } = default!;

    [Inject]
    IGradeService _gradeService { get; set; } = default!;

    public async Task SendGrade()
    {
        string[] studentName = student.Split(" ");
        postGradeModel.StudentFirstName = studentName[0];
        postGradeModel.StudentLastName = studentName[1];
        postGradeModel.Grade = examGrade;
        postGradeModel.CourseId = 1;
        postGradeModel.Notice = notice;
        var response = await _gradeService.PostGradeAsync(postGradeModel);
    }
}
