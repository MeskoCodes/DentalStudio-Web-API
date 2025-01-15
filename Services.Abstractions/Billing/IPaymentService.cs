namespace Contract.Billing
{
    public interface IPaymentService
    {
        Task<IEnumerable<PaymentDto>> GetAllAsync(CancellationToken cancellationToken);
        Task<PaymentDto> GetByIdAsync(int paymentId, CancellationToken cancellationToken);
        Task CreateAsync(PaymentCreateDto paymentDto, CancellationToken cancellationToken);
        Task UpdateAsync(int paymentId, PaymentUpdateDto paymentDto, CancellationToken cancellationToken);
        Task DeleteAsync(int paymentId, CancellationToken cancellationToken);
    }
}
