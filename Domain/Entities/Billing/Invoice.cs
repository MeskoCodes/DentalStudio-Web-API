namespace Domain.Entities.Billing;

    public class Invoice
    {
    public int InvoiceId { get; set; }
    public string? InvoiceNumber { get; set; }
    public DateTime IssuedDate { get; set; }
    public decimal TotalAmount { get; set; }
    public string? Status { get; set; } = string.Empty;

            public ICollection<Payment> Payments { get; set; }
        }
    
