namespace Domain.Entities.Billing
{
    public class Invoice
    {
        public int InvoiceId { get; set; }
        public string InvoiceNumber { get; set; } = string.Empty;
        public DateTime IssuedDate { get; set; }
        public decimal TotalAmount { get; set; }
        public string Status { get; set; } = string.Empty;
      

        public virtual ICollection<Payment> Payment { get; set; } = new List<Payment>();

        public int EmployeeId { get; set; }
        public virtual Employee Employee { get; set; }
    }
}
