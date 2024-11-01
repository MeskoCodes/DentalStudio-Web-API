using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Contract.Scheduling
{
    public class AppointmentDto
    {
        public int AppointmentId { get; set; }
        public int EmployeeId { get; set; }
        public int TreatmentId { get; set; }
        public int PatientId { get; set; }
        public DateTime AppointmentDate { get; set; }
        public TimeSpan AppointmentTime { get; set; }
        public string Status { get; set; } = string.Empty;
    }

    public class AppointmentCreateDto
    {
        public int EmployeeId { get; set; }
        public int TreatmentId { get; set; }
        public int PatientId { get; set; }
        public DateTime AppointmentDate { get; set; }
        public TimeSpan AppointmentTime { get; set; }
    }

    public class AppointmentUpdateDto
    {
        public int AppointmentId { get; set; }
        public int EmployeeId { get; set; }
        public int TreatmentId { get; set; }
        public int PatientId { get; set; }
        public DateTime AppointmentDate { get; set; }
        public TimeSpan AppointmentTime { get; set; }
        public string Status { get; set; } = string.Empty;
    }
}
