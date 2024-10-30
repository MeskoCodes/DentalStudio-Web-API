using Contract.Billing; // Pretpostavljam da je InvoiceDto ovde
using Domain.Entities;
using Domain.Repositories;
using Mapster;
using Services.Abstractions;

namespace Services.Billing
{
    public class InvoiceService : IInvoiceService
    {
        private readonly IRepositoryManager repositoryManager;

        public InvoiceService(IRepositoryManager repositoryManager)
        {
            this.repositoryManager = repositoryManager;
        }

        public async Task<GeneralResponseDto> Create(InvoiceDto invoiceDto, CancellationToken cancellationToken = default)
        {
            try
            {
                var invoice = invoiceDto.Adapt<Invoice>();
                repositoryManager.InvoiceRepository.CreateInvoice(invoice);
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

        // Implementiraj ostale metode kao što su Delete, GetAll, GetById, Update
    }
}
