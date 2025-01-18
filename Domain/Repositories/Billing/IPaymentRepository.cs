using Domain.Entities.Billing;

using Domain.Repositories.Common;

namespace Domain.Repositories;

public interface IPaymentRepository : IRepositoryBase<Payment>
{
    Task<IEnumerable<Payment>> GetAll(CancellationToken cancellationToken = default);

    Task<Payment> GetById(int paymentId, CancellationToken cancellationToken = default);

    void CreatePayment(Payment payment, CancellationToken cancellationToken = default);

    void DeletePayment(Payment payment, CancellationToken cancellationToken = default);

    void UpdatePayment(Payment payment, CancellationToken cancellationToken = default);
}