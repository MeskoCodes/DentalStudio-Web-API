using Contract.Billing;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Services.Abstractions.Billing
{
    public interface IPaymentService
    {
        Task<IEnumerable<PaymentDto>> GetAllAsync(CancellationToken cancellationToken);
        Task<PaymentDto> GetByIdAsync(int paymentId, CancellationToken cancellationToken);
        Task<GeneralResponseDto> CreateAsync(PaymentCreateDto paymentDto, CancellationToken cancellationToken);
        Task<GeneralResponseDto> UpdateAsync(int paymentId, PaymentUpdateDto paymentDto, CancellationToken cancellationToken);
        Task<GeneralResponseDto> DeleteAsync(int paymentId, CancellationToken cancellationToken);
    }
}
