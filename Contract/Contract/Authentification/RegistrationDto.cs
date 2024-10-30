using System.ComponentModel.DataAnnotations;

namespace Contract.Authentification;

public class RegistrationDto
{
    public string? FirstName { get; set; } = null!;
    public string? LastName { get; set; } = null!;
    public string? Email { get; set; }

    [Required(ErrorMessage = "Obavezno polje.")]
    [RegularExpression(@"(?=.*\d)(?=.*[a-z])(?=.*[A-Z]).*",
    ErrorMessage = "Lozinka mora imati najmanje 7 karaktera i sadržati barem jedno veliko slovo i jedan broj!")]
    [StringLength(16, MinimumLength = 7, ErrorMessage = "Najmanje 7 karaktera.")]
    [DataType(DataType.Password)]
    public string Password { get; set; } = null!;

    [Required(ErrorMessage = "Obavezno polje.")]
    [Compare(nameof(Password), ErrorMessage = "Lozinke se ne poklapaju.")]
    public string ConfirmPassword { get; set; } = null!;

    public string? PhoneNumber { get; set; } = null!;
    public string? Role { get; set; }
}
