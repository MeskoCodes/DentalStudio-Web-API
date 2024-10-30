using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities.Billing;

public class Invoice
{
    public int InvoiceId { get; set; }  // Jedinstveni ID računa
    public string InvoiceNumber { get; set; } = string.Empty;  // Broj računa
    public decimal Amount { get; set; }  // Iznos računa
    public DateTime DateIssued { get; set; }  // Datum izdavanja računa
    public DateTime? DueDate { get; set; }  // Datum dospeća
    public bool IsPaid { get; set; }  // Status plaćanja

    // Navigaciona svojstva
    public virtual ICollection<Payment> Payment { get; set; } = new List<Payment>();
}
