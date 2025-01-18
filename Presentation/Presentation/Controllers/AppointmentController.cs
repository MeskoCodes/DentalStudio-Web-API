using Contract;
using Microsoft.AspNetCore.Mvc;
using Services.Abstractions;

namespace Presentation.Controllers
{
    [ApiController]
    [Route("api/appointments")]
    public class AppointmentController(IServiceManager serviceManager) : ControllerBase
    {
        [HttpGet]
        [HttpGet]
        public async Task<IActionResult> GetAllAppointments(CancellationToken cancellationToken)
        {
            var response = await serviceManager.AppointmentService.GetAll(cancellationToken);
            return Ok(response);
        }


        [HttpDelete("{appointmentId}")]
        public async Task<IActionResult> Delete(int appointmentId, CancellationToken cancellationToken)
        {
            await serviceManager.AppointmentService.Delete(appointmentId, cancellationToken);
            return NoContent();
        }

        [HttpPost("create")]
        public async Task<IActionResult> Create([FromBody] AppointmentCreateDto appointmentDto, CancellationToken cancellationToken)
        {
            var response = await serviceManager.AppointmentService.Create(appointmentDto, cancellationToken);
            return Ok(response);
        }

        [HttpGet("details/{appointmentId}")]
        public async Task<IActionResult> GetAppointmentById(int appointmentId, CancellationToken cancellationToken)
        {
            var response = await serviceManager.AppointmentService.GetById(appointmentId, cancellationToken);
            return Ok(response);
        }


        [HttpPut("update/{appointmentId}")]
        public async Task<IActionResult> UpdateAppointment(int appointmentId, [FromBody] AppointmentUpdateDto appointmentDto, CancellationToken cancellationToken)
        {
            var response = await serviceManager.AppointmentService.Update(appointmentId, appointmentDto, cancellationToken);
            return Ok(response);
        }
    }
}