using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Notenverwaltung.Shared.Dtos.GradeDtos
{
    public class PostGradeDto
    {
        [Required(ErrorMessage = "Vorname ist erforderlich")]
        public string StudentFirstName { get; set; } = string.Empty;

        [Required(ErrorMessage = "Nachname ist erforderlich")]
        public string StudentLastName { get; set; } = string.Empty;

        [Required(ErrorMessage = "Fach ist erforderlich")]
        public int CourseId { get; set; }

        [Required(ErrorMessage = "Note ist erforderlich")]
        [Range(1, 6, ErrorMessage = "Die Note muss zwischen 1 und 6 liegen")]
        public float Grade { get; set; }

        public string? Notice { get; set; }
    }
}
