using Contract;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Services.Abstractions;

namespace Presentation
{
    [ApiController]
    [Route("api/appointments")]
    public class AppointmentController : ControllerBase
    {
        private readonly IServiceManager _serviceManager;

        public AppointmentController(IServiceManager serviceManager)
        {
            _serviceManager = serviceManager;
        }

        [Authorize]
        [HttpGet]
        public async Task<IActionResult> GetAllAppointments(CancellationToken cancellationToken)
        {
            var response = await _serviceManager.AppointmentService.GetAllAsync(cancellationToken);
            return Ok(response);
        }

        [Authorize]
        [HttpGet("{appointmentId}")]
        public async Task<IActionResult> GetAppointmentById(int appointmentId, CancellationToken cancellationToken)
        {
            var response = await _serviceManager.AppointmentService.GetByIdAsync(appointmentId, cancellationToken);
            return Ok(response);
        }

        [Authorize]
        [HttpPost("create")]
        public async Task<IActionResult> Create([FromBody] AppointmentCreateDto appointmentDto, CancellationToken cancellationToken)
        {
            await _serviceManager.AppointmentService.CreateAsync(appointmentDto, cancellationToken);
            return Ok(); // Vraćamo Ok() kao potvrdu uspešnog kreiranja
        }

        [Authorize]
        [HttpPut("update/{appointmentId}")]
        public async Task<IActionResult> Update(int appointmentId, [FromBody] AppointmentUpdateDto appointmentDto, CancellationToken cancellationToken)
        {
            await _serviceManager.AppointmentService.UpdateAsync(appointmentId, appointmentDto, cancellationToken);
            return NoContent();
        }

        [Authorize(Roles = "Admin")]
        [HttpDelete("delete/{appointmentId}")]
        public async Task<IActionResult> Delete(int appointmentId, CancellationToken cancellationToken)
        {
            await _serviceManager.AppointmentService.DeleteAsync(appointmentId, cancellationToken);
            return NoContent();
        }
    }
}
