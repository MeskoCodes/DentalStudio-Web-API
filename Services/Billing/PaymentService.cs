using Contract.Billing; // Pretpostavljam da je PaymentDto ovde
using Domain.Entities;
using Domain.Repositories;
using Mapster;
using Services.Abstractions;

namespace Services.Billing
{
    public class PaymentService : IPaymentService
    {
        private readonly IRepositoryManager repositoryManager;

        public PaymentService(IRepositoryManager repositoryManager)
        {
            this.repositoryManager = repositoryManager;
        }

        public async Task<GeneralResponseDto> ProcessPayment(PaymentDto paymentDto, CancellationToken cancellationToken = default)
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
                        Message = "Error processing payment!"
                    };
                }

                return new GeneralResponseDto { Message = "Payment processed successfully!" };
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

        // Implementiraj ostale metode kao što su Delete, GetAll, GetById, Update
    }
}
