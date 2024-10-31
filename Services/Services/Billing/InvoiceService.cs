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
    public class InvoiceService : IInvoiceService
    {
        private readonly IRepositoryManager _repositoryManager;

        public InvoiceService(IRepositoryManager repositoryManager)
        {
            _repositoryManager = repositoryManager;
        }

        public async Task<GeneralResponseDto> Create(InvoiceCreateDto invoiceDto, CancellationToken cancellationToken = default)
        {
            try
            {
                var invoice = invoiceDto.Adapt<Invoice>();
                _repositoryManager.InvoiceRepository.CreateInvoice(invoice);
                var rowsAffected = await _repositoryManager.UnitOfWork.SaveChangesAsync(cancellationToken);
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

        public Task<GeneralResponseDto> CreateInvoice(InvoiceCreateDto invoiceDto, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<GeneralResponseDto> DeleteInvoice(string invoiceId, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<InvoiceDto>> GetAllInvoices(CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<InvoiceDto> GetInvoiceById(string invoiceId, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<GeneralResponseDto> UpdateInvoice(string invoiceId, InvoiceUpdateDto invoiceDto, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        // Implement other methods (Delete, GetAll, GetById, Update) similarly
    }
}
