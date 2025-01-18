using Contract.Billing;
using Domain.Entities.Billing;
using Domain.Repositories.Common;

namespace Services
{
    public class PaymentService(IRepositoryManager repositoryManager) : IPaymentService
    {
        public async Task<GeneralResponseDto> Create(PaymentCreateDto paymentDto, CancellationToken cancellationToken = default)
        {
            try
            {
                var payment = paymentDto.Adapt<Payment>();
                repositoryManager.PaymentRepository.CreatePayment(payment);
                var rowsAffected = await repositoryManager.UnitOfWork.SaveChangesAsync(cancellationToken);
                if (rowsAffected != 1)
                {
                    return new GeneralResponseDto
                    {
                        IsSuccess = false,
                        Message = "Error!"
                    };
                }

                return new GeneralResponseDto { Data = payment.PaymentId, Message = "Success!" };
            }
            catch (Exception ex)
            {
                return new GeneralResponseDto
                {
                    IsSuccess = false,
                    Message = ex.Message
                };
            }
        }

        public async Task Delete(int paymentId, CancellationToken cancellationToken = default)
        {
            var payment = await repositoryManager.PaymentRepository.GetById(paymentId, cancellationToken);
            repositoryManager.PaymentRepository.DeletePayment(payment, cancellationToken);
            await repositoryManager.UnitOfWork.SaveChangesAsync(cancellationToken);
        }

        public async Task<IEnumerable<PaymentDto>> GetAll(CancellationToken cancellationToken = default)
        {
            var payments = await repositoryManager.PaymentRepository.GetAll(cancellationToken);
            return payments.Adapt<IEnumerable<PaymentDto>>();
        }

        public async Task<PaymentDto> GetById(int paymentId, CancellationToken cancellationToken = default)
        {
            var payment = await repositoryManager.PaymentRepository.GetById(paymentId, cancellationToken);
            return payment.Adapt<PaymentDto>();
        }

        public async Task<GeneralResponseDto> Update(int paymentId, PaymentUpdateDto paymentDto, CancellationToken cancellationToken = default)
        {
            try
            {
                var existingPayment = await repositoryManager.PaymentRepository.GetById(paymentId, cancellationToken);
                if (existingPayment == null)
                    return new GeneralResponseDto { IsSuccess = false, Message = "Payment not found." };

                paymentDto.Adapt(existingPayment);

                repositoryManager.PaymentRepository.UpdatePayment(existingPayment);
                var res = await repositoryManager.UnitOfWork.SaveChangesAsync(cancellationToken);
                if (res != 1)
                    return new GeneralResponseDto { IsSuccess = false };

                return new GeneralResponseDto { Data = existingPayment.PaymentId, Message = "Success!" };
            }
            catch (Exception ex)
            {
                return new GeneralResponseDto
                {
                    IsSuccess = false,
                    Message = ex.Message
                };
            }
        }
    }
}