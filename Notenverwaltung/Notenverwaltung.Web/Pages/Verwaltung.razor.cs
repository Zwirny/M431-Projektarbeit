using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using Notenverwaltung.Shared.Dtos.GradeDtos;
using Notenverwaltung.Web.Services.Abstract;

namespace Notenverwaltung.Web.Pages;

public partial class Verwaltung
{

    PostGradeDto gradeModel = new();

    PostGradeDto postGradeModel = new PostGradeDto();

    public int isSuccess;

    [Inject]
    public IJSRuntime JSRuntime { get; set; } = default!;

    [Inject]
    IGradeService _gradeService { get; set; } = default!;

    public async Task SendGrade()
    {
        postGradeModel = gradeModel;   
        postGradeModel.CourseId = 1;

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
