using Domain.Entities.Billing;
using Domain.Repositories.Billing;
using Microsoft.EntityFrameworkCore;

namespace Persistence.Repositories.Billing
{
    public class InvoiceRepository(DataContext dataContext) : RepositoryBase<Invoice>(dataContext), IInvoiceRepository
    {
        public void CreateInvoice(Invoice invoice) => Create(invoice);

        public void DeleteInvoice(Invoice invoice) => Delete(invoice);

        public void UpdateInvoice(Invoice invoice) => Update(invoice);

        public async Task<IEnumerable<Invoice>> GetAllAsync(CancellationToken cancellationToken = default)
        {
            return await FindAll().ToListAsync(cancellationToken);
        }

        public async Task<Invoice?> GetByIdAsync(int invoiceId, CancellationToken cancellationToken = default)
        {
            return await FindByCondition(invoice => invoice.InvoiceId == invoiceId)
                .FirstOrDefaultAsync(cancellationToken);
        }
    }
}
