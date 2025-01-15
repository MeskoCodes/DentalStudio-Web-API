using Contract.Billing;
using Domain.Entities.Billing;
using Domain.Repositories.Common;

namespace Services
{
    public class InvoiceService : IInvoiceService
    {
        private readonly IRepositoryManager _repositoryManager;

        public InvoiceService(IRepositoryManager repositoryManager)
        {
            _repositoryManager = repositoryManager;
        }

        public async Task<IEnumerable<InvoiceDto>> GetAllAsync(CancellationToken cancellationToken)
        {
            var invoice = await _repositoryManager.InvoiceRepository.GetAllAsync(cancellationToken);
            return invoice.Adapt<IEnumerable<InvoiceDto>>();
        }

        public async Task<InvoiceDto> GetById(int invoiceId, CancellationToken cancellationToken)
        {
            var invoice = await _repositoryManager.InvoiceRepository.GetByIdAsync(invoiceId, cancellationToken);
            return invoice.Adapt<InvoiceDto>();
        }

        public async Task CreateAsync(InvoiceCreateDto invoiceDto, CancellationToken cancellationToken)
        {
            var invoice = invoiceDto.Adapt<Invoice>();
            _repositoryManager.InvoiceRepository.CreateInvoice(invoice);
            await _repositoryManager.UnitOfWork.SaveChangesAsync(cancellationToken);
        }

        public async Task UpdateAsync(int invoiceId, InvoiceUpdateDto invoiceDto, CancellationToken cancellationToken)
        {
            var invoice = await _repositoryManager.InvoiceRepository.GetByIdAsync(invoiceId, cancellationToken);
            invoice.InvoiceId = invoiceDto.InvoiceId;
            invoice.TotalAmount = invoiceDto.TotalAmount;
            invoice.InvoiceNumber = invoiceDto.InvoiceNumber;
            invoice.Status = invoiceDto.Status;

            await _repositoryManager.UnitOfWork.SaveChangesAsync(cancellationToken);
        }

        public async Task DeleteAsync(int invoiceId, CancellationToken cancellationToken)
        {
            var invoice = await _repositoryManager.InvoiceRepository.GetByIdAsync(invoiceId, cancellationToken);
            _repositoryManager.InvoiceRepository.DeleteInvoice(invoice);
            await _repositoryManager.UnitOfWork.SaveChangesAsync(cancellationToken);
        }
        public Task<InvoiceDto> GetByIdAsync(int invoiceId, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

    }
}
