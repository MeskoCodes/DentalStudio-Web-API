using Domain.Entities;

public class Patient
{
    public int Id { get; set; }
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
    public string? MobileNumber { get; set; }
    public string? Email { get; set; }
    public DateTime DateOfBirth { get; set; } // Dodan datum rođenja
    public DateTime RegistrationDate { get; set; } // Dodan datum registracije

    public virtual ICollection<Appointment> Appointments { get; set; } = new List<Appointment>();
}
