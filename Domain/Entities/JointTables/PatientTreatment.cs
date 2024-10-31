using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System;
using Domain.Entities;

namespace Domain.Entities.JointTables
{
   public class PatientTreatment
    {
        public int PatientId { get; set; }  // Referenca na pacijenta
        public virtual Patient Patient { get; set; } = null!;  // Povezan pacijent

        public int TreatmentId { get; set; }  // Referenca na tretman
        public virtual Treatment Treatment { get; set; } = null!;  // Povezani tretman

        public DateTime DateOfTreatment { get; set; }  // Datum kada je tretman izvršen
        public string? Notes { get; set; }  // Beleške specifične za tretman za pacijenta

        public decimal Cost { get; set; }  // Troškovi tretmana za pacijenta (opciono)
    }
}
