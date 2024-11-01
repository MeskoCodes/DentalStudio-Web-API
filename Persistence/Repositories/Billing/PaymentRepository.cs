using Domain.Entities.Billing;
using Domain.Repositories;
using Domain.Repositories.Billing;
using Microsoft.EntityFrameworkCore;

namespace Persistence.Repositories.Billing
{
    public class PaymentRepository(DataContext dataContext) : RepositoryBase<Payment>(dataContext), IPaymentRepository
    {
        public void CreatePayment(Payment payment) => Create(payment);

        public void DeletePayment(Payment payment) => Delete(payment);

        public void UpdatePayment(Payment payment) => Update(payment);

        public async Task<IEnumerable<Payment>> GetAllAsync(CancellationToken cancellationToken = default)
        {
            return await FindAll().ToListAsync(cancellationToken);
        }

        public async Task<Payment?> GetByIdAsync(int paymentId, CancellationToken cancellationToken = default)
        {
            return await FindByCondition(payment => payment.PaymentId == paymentId)
                .FirstOrDefaultAsync(cancellationToken);
        }
    }
}
