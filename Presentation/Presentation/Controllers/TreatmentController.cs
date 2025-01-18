using Contract;
using Microsoft.AspNetCore.Mvc;
using Services.Abstractions;

namespace Presentation.Controllers
{
    [ApiController]
    [Route("api/treatments")]
    public class TreatmentController(IServiceManager serviceManager) : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> GetAllTreatments(CancellationToken cancellationToken)
        {
            var response = await serviceManager.TreatmentService.GetAll(cancellationToken);
            return Ok(response);
        }

        [HttpDelete("{treatmentId}")]
        public async Task<IActionResult> Delete(int treatmentId, CancellationToken cancellationToken)
        {
            await serviceManager.TreatmentService.Delete(treatmentId, cancellationToken);
            return NoContent();
        }

        [HttpPost("create")]
        public async Task<IActionResult> Create([FromBody] TreatmentCreateDto treatmentDto, CancellationToken cancellationToken)
        {
            var response = await serviceManager.TreatmentService.Create(treatmentDto, cancellationToken);
            return Ok(response);
        }

        [HttpGet("details/{treatmentId}")]
        public async Task<IActionResult> GetTreatmentById(int treatmentId, CancellationToken cancellationToken)
        {
            var response = await serviceManager.TreatmentService.GetById(treatmentId, cancellationToken);
            return Ok(response);
        }


        [HttpPut("update/{treatmentId}")]
        public async Task<IActionResult> UpdateTreatment(int treatmentId, [FromBody] TreatmentUpdateDto treatmentDto, CancellationToken cancellationToken)
        {
            var response = await serviceManager.TreatmentService.Update(treatmentId, treatmentDto, cancellationToken);
            return Ok(response);
        }
    }
}