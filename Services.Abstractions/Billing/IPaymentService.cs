namespace Services.Abstractions;
using Contract.Billing;

public interface IPaymentService
{
    Task<IEnumerable<PaymentDto>> GetAll(CancellationToken cancellationToken = default);

    Task<PaymentDto> GetById(int paymentId, CancellationToken cancellationToken = default);

    Task Delete(int paymentId, CancellationToken cancellationToken = default);

    Task<GeneralResponseDto> Create(PaymentCreateDto paymentDto, CancellationToken cancellationToken = default);

    Task<GeneralResponseDto> Update(int paymentId, PaymentUpdateDto paymentDto, CancellationToken cancellationToken = default);
}