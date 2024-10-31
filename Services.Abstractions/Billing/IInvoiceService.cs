using Contract.Billing;
using Contract;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Services.Abstractions.Billing
{
    public interface IInvoiceService
    {
        Task<GeneralResponseDto> CreateInvoice(InvoiceCreateDto invoiceDto, CancellationToken cancellationToken = default);
        Task<GeneralResponseDto> UpdateInvoice(string invoiceId, InvoiceUpdateDto invoiceDto, CancellationToken cancellationToken = default);
        Task<GeneralResponseDto> DeleteInvoice(string invoiceId, CancellationToken cancellationToken = default);
        Task<InvoiceDto> GetInvoiceById(string invoiceId, CancellationToken cancellationToken = default);
        Task<IEnumerable<InvoiceDto>> GetAllInvoices(CancellationToken cancellationToken = default);
    }
}
