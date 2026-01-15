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
        [Required]
        public string StudentFirstName { get; set; }
        [Required]
        public string StudentLastName { get; set; }
        [Required]
        public int CourseId { get; set; }
        [Required]
        [Range(1, 6)]
        public float Grade { get; set; }
        public string Notice { get; set; }
    }
}
