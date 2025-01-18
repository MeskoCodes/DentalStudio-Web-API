using Domain.Entities;
using Domain.Entities.Billing;
using Domain.Repositories.Common;

namespace Domain.Repositories;

public interface IInvoiceRepository : IRepositoryBase<Invoice>
{
    Task<IEnumerable<Invoice>> GetAll(CancellationToken cancellationToken = default);

    Task<Invoice> GetById(int invoiceId, CancellationToken cancellationToken = default);

    void CreateInvoice(Invoice invoice, CancellationToken cancellationToken = default);

    void DeleteInvoice(Invoice invoice, CancellationToken cancellationToken = default);

    void UpdateInvoice(Invoice invoice, CancellationToken cancellationToken = default);
}
