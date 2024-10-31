using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Domain.Entities;
using Domain.Entities.Billing;

namespace Domain.Repositories
{
    public interface IPaymentRepository
    {
        Task<Payment> GetByIdAsync(int paymentId, CancellationToken cancellationToken = default);
        Task<IEnumerable<Payment>> GetAllAsync(CancellationToken cancellationToken = default);
        void CreatePayment(Payment payment);
        void UpdatePayment(Payment payment);
        void DeletePayment(Payment payment);
    }
}
