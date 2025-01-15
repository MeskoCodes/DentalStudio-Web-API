using Contract;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Services.Abstractions;

namespace MDental.UI.Controllers
{
    [ApiController]
    [Route("api/treatments")]
    public class TreatmentController : ControllerBase
    {
        private readonly IServiceManager _serviceManager;

        public TreatmentController(IServiceManager serviceManager)
        {
            _serviceManager = serviceManager;
        }

        [Authorize]
        [HttpGet]
        public async Task<IActionResult> GetAllTreatments(CancellationToken cancellationToken)
        {
            var response = await _serviceManager.TreatmentService.GetAllAsync(cancellationToken);
            return Ok(response);
        }

        [Authorize(Roles = "Admin")]
        [HttpDelete("delete/{treatmentId}")]
        public async Task<IActionResult> Delete(int treatmentId, CancellationToken cancellationToken)
        {
            await _serviceManager.TreatmentService.DeleteAsync(treatmentId, cancellationToken);
            return NoContent();
        }

        [HttpPost("create")]
        public async Task<IActionResult> Create([FromBody] TreatmentCreateDto treatmentDto, CancellationToken cancellationToken)
        {
            await _serviceManager.TreatmentService.CreateAsync(treatmentDto, cancellationToken);
            return Ok(); // Vraćamo Ok() kao potvrdu uspešnog kreiranja
        }

        [Authorize]
        [HttpGet("details/{treatmentId}")]
        public async Task<IActionResult> GetTreatmentById(int treatmentId, CancellationToken cancellationToken)
        {
            var response = await _serviceManager.TreatmentService.GetByIdAsync(treatmentId, cancellationToken);
            return Ok(response);
        }

        [Authorize]
        [HttpPut("update/{treatmentId}")]
        public async Task<IActionResult> UpdateTreatment(int treatmentId, [FromBody] TreatmentUpdateDto treatmentDto, CancellationToken cancellationToken)
        {
            await _serviceManager.TreatmentService.UpdateAsync(treatmentId, treatmentDto, cancellationToken);
            return NoContent();
        }
    }
}
