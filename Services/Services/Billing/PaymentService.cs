using Contract.Billing;
using Domain.Entities.Billing;
using Domain.Repositories.Common;

namespace Services
{
    public class PaymentService : IPaymentService
    {
        private readonly IRepositoryManager _repositoryManager;

        public PaymentService(IRepositoryManager repositoryManager)
        {
            _repositoryManager = repositoryManager;
        }
        public async Task<IEnumerable<PaymentDto>> GetAllAsync(CancellationToken cancellationToken)
        {
            var payment = await _repositoryManager.PaymentRepository.GetAllAsync(cancellationToken);
            return payment.Adapt<IEnumerable<PaymentDto>>();
        }

        public async Task<PaymentDto> GetByIdAsync(int paymentId, CancellationToken cancellationToken)
        {
            var payment = await _repositoryManager.PaymentRepository.GetByIdAsync(paymentId, cancellationToken);
            return payment.Adapt<PaymentDto>();
        }

        public async Task CreateAsync(PaymentCreateDto paymentDto, CancellationToken cancellationToken)
        {
            var payment = paymentDto.Adapt<Payment>();
            _repositoryManager.PaymentRepository.CreatePayment(payment);
            await _repositoryManager.UnitOfWork.SaveChangesAsync(cancellationToken);
        }

        public async Task UpdateAsync(int paymentId, PaymentUpdateDto paymentDto, CancellationToken cancellationToken)
        {
            var payment = await _repositoryManager.PaymentRepository.GetByIdAsync(paymentId, cancellationToken);

            if (payment == null)
            {
                throw new KeyNotFoundException($"Payment with ID {paymentId} not found.");
            }

            payment.InvoiceId = paymentDto.InvoiceId;
            payment.Amount = paymentDto.Amount;
            payment.PaymentDate = paymentDto.PaymentDate;
            payment.PaymentMethod = paymentDto.PaymentMethod;

            await _repositoryManager.UnitOfWork.SaveChangesAsync(cancellationToken);
        }


        public async Task DeleteAsync(int paymentId, CancellationToken cancellationToken)
        {
            var payment = await _repositoryManager.PaymentRepository.GetByIdAsync(paymentId, cancellationToken);
            _repositoryManager.PaymentRepository.DeletePayment(payment);
            await _repositoryManager.UnitOfWork.SaveChangesAsync(cancellationToken);
        }

    }
}
