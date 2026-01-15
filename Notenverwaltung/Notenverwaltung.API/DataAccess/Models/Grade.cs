using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Notenverwaltung.API.DataAccess.Models;

[Table("noten")]
public class Grade
{
    [Key]
    public int Id { get; set; }
    [Required]
    public int LehrpersonID { get; set; }
    [Required]
    public int KursID { get; set; }
    [Required]
    [Range(1, 6)]
    public float Note { get; set; }
    public string Bemerkung { get; set; }
    [Required]
    public string SchuelerVorname { get; set; }
    [Required]
    public string SchuelerNachname { get; set; }

}
