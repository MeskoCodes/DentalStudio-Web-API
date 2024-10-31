using Domain.Entities;
using Domain.Entities.Billing;

namespace Domain.Repositories.Billing
{
    public interface IInvoiceRepository
    {
        Task<Invoice> GetByIdAsync(int invoiceId, CancellationToken cancellationToken = default);
        Task<IEnumerable<Invoice>> GetAllAsync(CancellationToken cancellationToken = default);
        void CreateInvoice(Invoice invoice);
        void UpdateInvoice(Invoice invoice);
        void DeleteInvoice(Invoice invoice);
    }
}
