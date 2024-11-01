using Contract.Billing;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Services.Abstractions.Billing
{
    public interface IInvoiceService
    {
        Task<IEnumerable<InvoiceDto>> GetAllAsync(CancellationToken cancellationToken);
        Task<InvoiceDto> GetByIdAsync(int invoiceId, CancellationToken cancellationToken);
        Task<GeneralResponseDto> CreateAsync(InvoiceCreateDto invoiceDto, CancellationToken cancellationToken);
        Task<GeneralResponseDto> UpdateAsync(int invoiceId, InvoiceUpdateDto invoiceDto, CancellationToken cancellationToken);
        Task<GeneralResponseDto> DeleteAsync(int invoiceId, CancellationToken cancellationToken);

    }
}
