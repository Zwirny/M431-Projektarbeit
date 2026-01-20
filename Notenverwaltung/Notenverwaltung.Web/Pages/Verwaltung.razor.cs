using Microsoft.AspNetCore.Components;

namespace Notenverwaltung.Web.Pages;

public partial class Verwaltung
{
    public double examGrade;
    public double reportGrade;

    public void RoundReportGrade()
    {
        reportGrade = Math.Round(reportGrade * 2, MidpointRounding.AwayFromZero) / 2;
        if(reportGrade > 6)
        {
            reportGrade = 6;
        }
        else if(reportGrade < 1)
        {
            reportGrade = 1;
        }
    }
}
