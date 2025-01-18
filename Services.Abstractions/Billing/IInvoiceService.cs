using Contract.Billing;
using Services.Common.Dto.Billing;

namespace Services.Abstractions;

public interface IInvoiceService
{
    Task<IEnumerable<InvoiceDto>> GetAll(CancellationToken cancellationToken = default);

    Task<InvoiceDto> GetById(int invoiceId, CancellationToken cancellationToken = default);

    Task Delete(int invoiceId, CancellationToken cancellationToken = default);

    Task<GeneralResponseDto> Create(InvoiceCreateDto invoiceDto, CancellationToken cancellationToken = default);

    Task<GeneralResponseDto> Update(int invoiceId, InvoiceUpdateDto invoiceDto, CancellationToken cancellationToken = default);
}