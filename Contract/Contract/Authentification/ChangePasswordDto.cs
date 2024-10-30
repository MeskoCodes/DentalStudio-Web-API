using System.ComponentModel.DataAnnotations;

namespace Contract.Authentification;

public class ChangePasswordDto
{
    [Required(ErrorMessage = "Stara lozinka je obavezna.")]
    public string? OldPassword { get; set; }

    [Required(ErrorMessage = "Nova lozinka je obavezna.")]
    [RegularExpression(@"^((?=.*[a-z])(?=.*[A-Z])(?=.*\d)).+$",
        ErrorMessage =
            "Nova lozinka mora biti između 8 i 16 karaktera i sadržati barem jedno veliko slovo, jedno malo slovo, jedan broj i jedan simbol.")]
    [StringLength(16, MinimumLength = 8, ErrorMessage = "Lozinka mora imati najmanje 8 karaktera.")]
    [DataType(DataType.Password)]
    public string? NewPassword { get; set; }

    [Required(ErrorMessage = "Potvrdite novu lozinku.")]
    [Compare(nameof(NewPassword), ErrorMessage = "Lozinke se moraju poklapati.")]
    public string? ConfirmPassword { get; set; }

    public string? Email { get; set; }
}
