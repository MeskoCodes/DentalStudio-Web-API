using System;
using Domain.Entities.Scheduling;
using Domain.Entities;

namespace Domain.Entities.JointTables
{
    public class AppointmentTreatment
    {
        public int AppointmentId { get; set; }  // Referenca na termin
        public virtual Appointment Appointment { get; set; } = null!;  // Povezan termin

        public int TreatmentId { get; set; }  // Referenca na tretman
        public virtual Treatment Treatment { get; set; } = null!;  // Povezani tretman

        public string Notes { get; set; } = string.Empty;  // Dodatne beleške za tretman u okviru termina
        public DateTime? PerformedAt { get; set; }  // Datum kada je tretman izvršen (opciono)
    }
}
