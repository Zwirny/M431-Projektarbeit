using System.ComponentModel.DataAnnotations.Schema;

namespace Notenverwaltung.API.DataAccess.Models
{
    [Table("user")]
    public class User
    {
        public int Id { get; set; }
        public int StatusId { get; set; }
        public string Vorname { get; set; }
        public string Nachname { get; set; }
        public string Email { get; set; }
        public string Passwort { get; set; }

    }
}
