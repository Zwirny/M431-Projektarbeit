using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using Notenverwaltung.Shared.Dtos.CourseDtos;
using Notenverwaltung.Shared.Dtos.GradeDtos;
using Notenverwaltung.Web.Services;
using Notenverwaltung.Web.Services.Abstract;
using System.ComponentModel.DataAnnotations;

namespace Notenverwaltung.Web.Pages;

public partial class Verwaltung
{

    PostGradeDto gradeModel = new();

    PostGradeDto postGradeModel = new PostGradeDto();

    List<CourseDto> courses = new List<CourseDto>();

    private int courseId;

    public int isSuccess;

    [Inject]
    public IJSRuntime JSRuntime { get; set; } = default!;

    [Inject]
    IGradeService _gradeService { get; set; } = default!;

    [Inject]
    ICourseService _courseService { get; set; }

    protected override async Task OnInitializedAsync()
    {
        courses = await _courseService.GetCoursesAsync();
    }


    public async Task SendGrade()
    {
        postGradeModel = gradeModel;
        postGradeModel.CourseId = courseId;

        var response = await _gradeService.PostGradeAsync(postGradeModel);

        if (response.IsSuccessStatusCode)
        {
            isSuccess = 1;
            gradeModel = new PostGradeDto();
        }
        else
        {
            isSuccess = 2;
        }
    }
}
