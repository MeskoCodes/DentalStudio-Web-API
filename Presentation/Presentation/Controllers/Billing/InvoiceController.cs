using Contract;
using Contract.Billing;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Services.Abstractions;
using Services.Abstractions.Billing;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Presentation.Controllers.Billing
{
    [ApiController]
    [Route("api/invoices")]
    public class InvoiceController : ControllerBase
    {
        private readonly IServiceManager _serviceManager;

        public InvoiceController(IServiceManager serviceManager)
        {
            _serviceManager = serviceManager;
        }

        [Authorize]
        [HttpGet]
        public async Task<IActionResult> GetAllInvoices(CancellationToken cancellationToken)
        {
            var response = await _serviceManager.InvoiceService.GetAllAsync(cancellationToken);
            return Ok(response);
        }

        [Authorize(Roles = "Admin")]
        [HttpDelete("delete/{invoiceId}")]
        public async Task<IActionResult> Delete(int invoiceId, CancellationToken cancellationToken)
        {
            await _serviceManager.InvoiceService.DeleteAsync(invoiceId, cancellationToken);
            return NoContent();
        }

        [HttpPost("create")]
        public async Task<IActionResult> Create([FromBody] InvoiceCreateDto invoiceDto, CancellationToken cancellationToken)
        {
            await _serviceManager.InvoiceService.CreateAsync(invoiceDto, cancellationToken);
            return Ok();
        }

        [Authorize]
        [HttpGet("details/{invoiceId}")]
        public async Task<IActionResult> GetInvoiceById(int invoiceId, CancellationToken cancellationToken)
        {
            var response = await _serviceManager.InvoiceService.GetByIdAsync(invoiceId, cancellationToken);
            return Ok(response);
        }

        [Authorize]
        [HttpPut("update/{invoiceId}")]
        public async Task<IActionResult> UpdateInvoice(int invoiceId, [FromBody] InvoiceUpdateDto invoiceDto, CancellationToken cancellationToken)
        {
            await _serviceManager.InvoiceService.UpdateAsync(invoiceId, invoiceDto, cancellationToken);
            return NoContent();
        }
    }
}
