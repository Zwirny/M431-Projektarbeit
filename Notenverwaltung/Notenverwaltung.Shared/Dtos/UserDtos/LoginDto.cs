using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Notenverwaltung.Shared.Dtos.UserDtos
{
    public class LoginDto
    {
        [Required(ErrorMessage = "Email ist erforderlich")]
        [EmailAddress(ErrorMessage = "Ungültige Email")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Passwort ist erforderlich")]
        public string Passwort { get; set; }
    }
}
