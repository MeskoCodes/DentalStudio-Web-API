using Domain.Entities;

public class Employee
{
    public int EmployeeId { get; set; }
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
    public string Specialization { get; set; } = string.Empty;
    public string? Email { get; set; }
    public string? PhoneNumber { get; set; }
    public List<string> Roles { get; } = new List<string>();

    public virtual ICollection<Appointment> Appointments { get; set; } = new List<Appointment>();
}
