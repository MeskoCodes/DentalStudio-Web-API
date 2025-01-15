
namespace Domain.Entities.Billing;

public class Payment
{
    public int PaymentId { get; set; }  // Jedinstveni ID plaćanja
    public decimal Amount { get; set; }  // Iznos plaćanja
    public DateTime PaymentDate { get; set; }  // Datum plaćanja
    public string PaymentMethod { get; set; } = string.Empty;  // Način plaćanja, npr. kartica, gotovina

    public int InvoiceId { get; set; }  // Referenca na Invoice
    public virtual Invoice Invoice { get; set; } = null!;  // Povezan račun
}
