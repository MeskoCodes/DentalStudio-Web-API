using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities.Scheduling;

public class Appointment
{
    public int AppointmentId { get; set; }  
    public DateTime Date { get; set; } 
    public TimeSpan Time { get; set; }  
    public string TreatmentType { get; set; } = string.Empty; 

   
    public int EmployeeId { get; set; }  
    public virtual Employee Employee { get; set; } = null!; 

    public int PatientId { get; set; } 
    public virtual Patient Patient { get; set; } = null!; 
}
