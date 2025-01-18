using Domain.Entities.Billing;
using Domain.Repositories;

namespace Persistence.Repositories
{
    public class InvoiceRepository(DataContext dataContext) : RepositoryBase<Invoice>(dataContext), IInvoiceRepository
    {
        public void CreateInvoice(Invoice invoice, CancellationToken cancellationToken = default) => Create(invoice);

        public void DeleteInvoice(Invoice invoice, CancellationToken cancellationToken = default) => Delete(invoice);

        public void UpdateInvoice(Invoice invoice, CancellationToken cancellationToken = default) => Update(invoice);

        public async Task<IEnumerable<Invoice>> GetAll(CancellationToken cancellationToken = default)
        {
            return await FindAll().ToListAsync(cancellationToken);
        }

        public async Task<Invoice> GetById(int invoiceId, CancellationToken cancellationToken = default)
        {
            return await FindByCondition(i => i.InvoiceId == invoiceId)
                .FirstOrDefaultAsync(cancellationToken);
        }


    }
}