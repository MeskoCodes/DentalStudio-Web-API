
namespace Domain.Entities.Billing;

public class Payment
{
    public int PaymentId { get; set; }
    public decimal Amount { get; set; }
    public DateTime PaymentDate { get; set; }
    public string PaymentMethod { get; set; }

    // Foreign Key for Invoice
    public int InvoiceId { get; set; }
    public Invoice Invoice { get; set; } 

  
}