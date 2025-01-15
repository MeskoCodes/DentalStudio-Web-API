using Contract.Billing;

namespace Services.Abstractions
{
    public interface IInvoiceService
    {
        Task<IEnumerable<InvoiceDto>> GetAllAsync(CancellationToken cancellationToken);
        Task<InvoiceDto> GetByIdAsync(int invoiceId, CancellationToken cancellationToken);
        Task CreateAsync(InvoiceCreateDto invoiceDto, CancellationToken cancellationToken);
        Task UpdateAsync(int invoiceId, InvoiceUpdateDto invoiceDto, CancellationToken cancellationToken);
        Task DeleteAsync(int invoiceId, CancellationToken cancellationToken);
    }
}
