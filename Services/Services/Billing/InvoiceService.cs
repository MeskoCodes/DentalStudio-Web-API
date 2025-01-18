using Contract.Billing;
using Domain.Entities.Billing;
using Domain.Repositories.Common;
using Services.Common.Dto.Billing;

namespace Services
{
    public class InvoiceService(IRepositoryManager repositoryManager) : IInvoiceService
    {
        public async Task<GeneralResponseDto> Create(InvoiceCreateDto invoiceDto, CancellationToken cancellationToken = default)
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

                return new GeneralResponseDto { Data = invoice.InvoiceId, Message = "Success!" };
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

        public async Task Delete(int invoiceId, CancellationToken cancellationToken = default)
        {
            var invoice = await repositoryManager.InvoiceRepository.GetById(invoiceId, cancellationToken);
            repositoryManager.InvoiceRepository.DeleteInvoice(invoice, cancellationToken);
            await repositoryManager.UnitOfWork.SaveChangesAsync(cancellationToken);
        }

        public async Task<IEnumerable<InvoiceDto>> GetAll(CancellationToken cancellationToken = default)
        {
            var invoices = await repositoryManager.InvoiceRepository.GetAll(cancellationToken);
            return invoices.Adapt<IEnumerable<InvoiceDto>>();
        }

        public async Task<InvoiceDto> GetById(int invoiceId, CancellationToken cancellationToken = default)
        {
            var invoice = await repositoryManager.InvoiceRepository.GetById(invoiceId, cancellationToken);
            return invoice.Adapt<InvoiceDto>();
        }

        public async Task<GeneralResponseDto> Update(int invoiceId, InvoiceUpdateDto invoiceDto, CancellationToken cancellationToken = default)
        {
            try
            {
                var existingInvoice = await repositoryManager.InvoiceRepository.GetById(invoiceId, cancellationToken);
                if (existingInvoice == null)
                    return new GeneralResponseDto { IsSuccess = false, Message = "Invoice not found." };

                invoiceDto.Adapt(existingInvoice);

                repositoryManager.InvoiceRepository.UpdateInvoice(existingInvoice);
                var res = await repositoryManager.UnitOfWork.SaveChangesAsync(cancellationToken);
                if (res != 1)
                    return new GeneralResponseDto { IsSuccess = false };

                return new GeneralResponseDto { Data = existingInvoice.InvoiceId, Message = "Success!" };
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