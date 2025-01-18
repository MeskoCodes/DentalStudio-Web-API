using Contract.Billing;
using Microsoft.AspNetCore.Mvc;
using Services.Abstractions;

namespace Presentation.Controllers
{
    [ApiController]
    [Route("api/payments")]
    public class PaymentController(IServiceManager serviceManager) : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> GetAllPayments(CancellationToken cancellationToken)
        {
            var response = await serviceManager.PaymentService.GetAll(cancellationToken);
            return Ok(response);
        }

        [HttpDelete("{paymentId}")]
        public async Task<IActionResult> Delete(int paymentId, CancellationToken cancellationToken)
        {
            await serviceManager.PaymentService.Delete(paymentId, cancellationToken);
            return NoContent();
        }

        [HttpPost("create")]
        public async Task<IActionResult> Create([FromBody] PaymentCreateDto paymentDto, CancellationToken cancellationToken)
        {
            var response = await serviceManager.PaymentService.Create(paymentDto, cancellationToken);
            return Ok(response);
        }

        [HttpGet("details/{paymentId}")]
        public async Task<IActionResult> GetPaymentById(int paymentId, CancellationToken cancellationToken)
        {
            var response = await serviceManager.PaymentService.GetById(paymentId, cancellationToken);
            return Ok(response);
        }


        [HttpPut("update/{paymentId}")]
        public async Task<IActionResult> UpdatePayment(int paymentId, [FromBody] PaymentUpdateDto paymentDto, CancellationToken cancellationToken)
        {
            var response = await serviceManager.PaymentService.Update(paymentId, paymentDto, cancellationToken);
            return Ok(response);
        }
    }
}