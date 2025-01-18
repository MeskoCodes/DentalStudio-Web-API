using Domain.Entities.Billing;
using Domain.Repositories;


namespace Persistence.Repositories
{
    public class PaymentRepository(DataContext dataContext) : RepositoryBase<Payment>(dataContext), IPaymentRepository
    {
        public void CreatePayment(Payment payment, CancellationToken cancellationToken = default) => Create(payment);

        public void DeletePayment(Payment payment, CancellationToken cancellationToken = default) => Delete(payment);

        public void UpdatePayment(Payment payment, CancellationToken cancellationToken = default) => Update(payment);

        public async Task<IEnumerable<Payment>> GetAll(CancellationToken cancellationToken = default)
        {
            return await FindAll().ToListAsync(cancellationToken);
        }

        public async Task<Payment> GetById(int paymentId, CancellationToken cancellationToken = default)
        {
            return await FindByCondition(p => p.PaymentId == paymentId)
                .FirstOrDefaultAsync(cancellationToken);
        }


    }
}