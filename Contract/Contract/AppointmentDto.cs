namespace Contract
{
    public class AppointmentDto
    {
        public int AppointmentId { get; set; }
        public int EmployeeId { get; set; }
        public int TreatmentId { get; set; }
        public int PatientId { get; set; }
        public string PatientName { get; set; } = string.Empty;
        public DateTime AppointmentDate { get; set; }
        public TimeSpan AppointmentTime { get; set; }
        public string Status { get; set; } = string.Empty;
    }

    public class AppointmentCreateDto
    {
     
        public int EmployeeId { get; set; }
        public int TreatmentId { get; set; }
        public int PatientId { get; set; }
        public string PatientName { get; set; } = string.Empty; 
        public DateTime AppointmentDate { get; set; }
        public TimeSpan AppointmentTime { get; set; }
        public string Status { get; set; } = string.Empty;
    }

    public class AppointmentUpdateDto
    {
        public int AppointmentId { get; set; }
        public int EmployeeId { get; set; }
        public int TreatmentId { get; set; }
        public string PatientName { get; set; } = string.Empty; 
        public int PatientId { get; set; }
        public DateTime AppointmentDate { get; set; }
        public TimeSpan AppointmentTime { get; set; }
        public string Status { get; set; } = string.Empty;
    }
}
