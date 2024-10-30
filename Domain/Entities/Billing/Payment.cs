using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities.Billing;

public class Payment
{
    public int PaymentId { get; set; }  // Jedinstveni ID plaćanja
    public decimal Amount { get; set; }  // Iznos plaćanja
    public DateTime PaymentDate { get; set; }  // Datum plaćanja
    public string PaymentMethod { get; set; } = string.Empty;  // Način plaćanja, npr. kartica, gotovina

    // Navigaciono svojstvo za Invoice
    public int InvoiceId { get; set; }  // Referenca na Invoice
    public virtual Invoice Invoice { get; set; } = null!;  // Povezan račun
}
