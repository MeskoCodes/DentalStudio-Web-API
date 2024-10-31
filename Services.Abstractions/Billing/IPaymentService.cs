using Contract.Billing;
using Contract;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Services.Abstractions.Billing
{
    public interface IPaymentService
    {
        Task<GeneralResponseDto> CreatePayment(PaymentCreateDto paymentDto, CancellationToken cancellationToken = default);
        Task<GeneralResponseDto> UpdatePayment(string paymentId, PaymentUpdateDto paymentDto, CancellationToken cancellationToken = default);
        Task<GeneralResponseDto> DeletePayment(string paymentId, CancellationToken cancellationToken = default);
        Task<PaymentDto> GetPaymentById(string paymentId, CancellationToken cancellationToken = default);
        Task<IEnumerable<PaymentDto>> GetAllPayments(CancellationToken cancellationToken = default);
    }
}
