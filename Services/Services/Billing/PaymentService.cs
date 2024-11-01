using Contract;
using Contract.Billing;
using Domain.Entities;
using Domain.Entities.Billing;
using Domain.Repositories;
using Domain.Repositories.Common;
using Mapster;
using Services.Abstractions;
using Services.Abstractions.Billing;

namespace Services.Billing
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

                return new GeneralResponseDto { Message = "Success!" };
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

        public Task<GeneralResponseDto> CreateAsync(PaymentCreateDto paymentDto, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<GeneralResponseDto> CreatePayment(PaymentCreateDto paymentDto, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<GeneralResponseDto> DeleteAsync(int paymentId, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<GeneralResponseDto> DeletePayment(string paymentId, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<PaymentDto>> GetAllAsync(CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<PaymentDto>> GetAllPayments(CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<PaymentDto> GetByIdAsync(int paymentId, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<PaymentDto> GetPaymentById(string paymentId, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<GeneralResponseDto> UpdateAsync(int paymentId, PaymentUpdateDto paymentDto, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<GeneralResponseDto> UpdatePayment(string paymentId, PaymentUpdateDto paymentDto, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        // Implement other methods (Delete, GetAll, GetById, Update) similarly
    }
}
