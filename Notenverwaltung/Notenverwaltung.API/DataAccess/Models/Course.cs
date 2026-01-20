using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Notenverwaltung.API.DataAccess.Models
{
    [Table("kurs")]
    public class Course
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string KursName { get; set; }

        public string Beschreibung { get; set; }
    }
}
