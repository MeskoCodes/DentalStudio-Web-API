using System.ComponentModel.DataAnnotations;

namespace Contract.Authentification;

public class ResetPasswordDto
{
    public string? Email { get; set; }

    [Required(ErrorMessage = "Lozinka je obavezna.")]
    [RegularExpression(@"^((?=.*[a-z])(?=.*[A-Z])(?=.*\d)).+$",
        ErrorMessage = "Lozinka mora imati između 8 i 16 karaktera i sadržati najmanje jedno veliko slovo, jedno malo slovo, jedan broj i jedan simbol.")]
    [StringLength(16, MinimumLength = 7, ErrorMessage = "Najmanje 8 karaktera.")]
    [DataType(DataType.Password)]
    public string? NewPassword { get; set; }

    [Required(ErrorMessage = "Molimo potvrdite lozinku.")]
    [Compare(nameof(NewPassword), ErrorMessage = "Lozinke se moraju poklapati.")]
    public string? ConfirmPassword { get; set; }

    public string ResetPasswordToken { get; set; }
}
