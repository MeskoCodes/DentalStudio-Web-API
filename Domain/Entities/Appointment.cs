
namespace Domain.Entities;

public class Appointment
{
    public int AppointmentId { get; set; }

    public int TreatmentId { get; set; }
    public DateTime AppointmentDate { get; set; }
    public TimeSpan AppointmentTime { get; set; }
    public string Status { get; set; } = string.Empty;
    public int EmployeeId { get; set; }
    public virtual Employee Employee { get; set; } = null!;

    public int PatientId { get; set; }
    public virtual Patient Patient { get; set; } = null!;
}
