namespace Services.Common.Dto.Billing
{
    public class InvoiceDto
    {
        public int InvoiceId { get; set; }
        public string? InvoiceNumber { get; set; }
        public DateTime IssuedDate { get; set; }
        public decimal TotalAmount { get; set; }
        public string? Status { get; set; } = string.Empty;
    }

    public class InvoiceCreateDto
    {
        public int InvoiceId { get; set; }
        public string? InvoiceNumber { get; set; }
        public DateTime IssuedDate { get; set; }
        public decimal TotalAmount { get; set; }
        public string? Status { get; set; } = string.Empty;
    }

    public class InvoiceUpdateDto
    {
        public int InvoiceId { get; set; }
        public decimal TotalAmount { get; set; }
        public string? InvoiceNumber { get; set; }
        public DateTime IssuedDate { get; set; }
        public string? Status { get; set; } = string.Empty;

    }
}

