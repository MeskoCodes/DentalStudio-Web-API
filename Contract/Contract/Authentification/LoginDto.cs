using System.ComponentModel.DataAnnotations;

namespace Contract.Authentification;

public class LoginDto
{
    [Required(ErrorMessage = "E-mail adresa je obavezna!")]
    [EmailAddress(ErrorMessage = "E-mail nema ispravan format!")]
    public string? Email { get; set; }

    [Required(ErrorMessage = "Lozinka je obavezna!")]
    public string? Password { get; set; }
}
