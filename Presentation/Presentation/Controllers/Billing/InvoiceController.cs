using Contract.Billing;
using Microsoft.AspNetCore.Mvc;
using Services.Abstractions;
using Services.Common.Dto.Billing;

namespace Presentation.Controllers
{
    [ApiController]
    [Route("api/invoices")]
    public class InvoiceController(IServiceManager serviceManager) : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> GetAllInvoices(CancellationToken cancellationToken)
        {
            var response = await serviceManager.InvoiceService.GetAll(cancellationToken);
            return Ok(response);
        }

        [HttpDelete("{invoiceId}")]
        public async Task<IActionResult> Delete(int invoiceId, CancellationToken cancellationToken)
        {
            await serviceManager.InvoiceService.Delete(invoiceId, cancellationToken);
            return NoContent();
        }

        [HttpPost("create")]
        public async Task<IActionResult> Create([FromBody] InvoiceCreateDto invoiceDto, CancellationToken cancellationToken)
        {
            var response = await serviceManager.InvoiceService.Create(invoiceDto, cancellationToken);
            return Ok(response);
        }

        [HttpGet("details/{invoiceId}")]
        public async Task<IActionResult> GetInvoiceById(int invoiceId, CancellationToken cancellationToken)
        {
            var response = await serviceManager.InvoiceService.GetById(invoiceId, cancellationToken);
            return Ok(response);
        }


        [HttpPut("update/{invoiceId}")]
        public async Task<IActionResult> UpdateInvoice(int invoiceId, [FromBody] InvoiceUpdateDto invoiceDto, CancellationToken cancellationToken)
        {
            var response = await serviceManager.InvoiceService.Update(invoiceId, invoiceDto, cancellationToken);
            return Ok(response);
        }
    }
}