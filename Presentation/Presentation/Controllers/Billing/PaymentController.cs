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
    [Route("api/payments")]
    public class PaymentController : ControllerBase
    {
        private readonly IServiceManager _serviceManager;

        public PaymentController(IServiceManager serviceManager)
        {
            _serviceManager = serviceManager;
        }

        [Authorize]
        [HttpGet]
        public async Task<IActionResult> GetAllPayments(CancellationToken cancellationToken)
        {
            var response = await _serviceManager.PaymentService.GetAllAsync(cancellationToken);
            return Ok(response);
        }

        [Authorize(Roles = "Admin")]
        [HttpDelete("delete/{paymentId}")]
        public async Task<IActionResult> Delete(int paymentId, CancellationToken cancellationToken)
        {
            await _serviceManager.PaymentService.DeleteAsync(paymentId, cancellationToken);
            return NoContent();
        }

        [HttpPost("create")]
        public async Task<IActionResult> Create([FromBody] PaymentCreateDto paymentDto, CancellationToken cancellationToken)
        {
            await _serviceManager.PaymentService.CreateAsync(paymentDto, cancellationToken);
            return Ok();
        }

        [Authorize]
        [HttpGet("details/{paymentId}")]
        public async Task<IActionResult> GetPaymentById(int paymentId, CancellationToken cancellationToken)
        {
            var response = await _serviceManager.PaymentService.GetByIdAsync(paymentId, cancellationToken);
            return Ok(response);
        }

        [Authorize]
        [HttpPut("update/{paymentId}")]
        public async Task<IActionResult> UpdatePayment(int paymentId, [FromBody] PaymentUpdateDto paymentDto, CancellationToken cancellationToken)
        {
            await _serviceManager.PaymentService.UpdateAsync(paymentId, paymentDto, cancellationToken);
            return NoContent();
        }
    }
}
