using Contract;
using Contract.Account;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Services.Abstractions;
using System.Threading;
using System.Threading.Tasks;

namespace Presentation.Controllers
{
    [ApiController]
    [Route("api/patients")]
    public class PatientController : ControllerBase
    {
        private readonly IServiceManager _serviceManager;

        public PatientController(IServiceManager serviceManager) // Promenio sam naziv konstruktoru
        {
            _serviceManager = serviceManager;
        }

        [Authorize]
        [HttpGet]
        public async Task<IActionResult> GetAllPatients(CancellationToken cancellationToken)
        {
            var response = await _serviceManager.PatientService.GetAllAsync(cancellationToken);
            return Ok(response);
        }

        [Authorize(Roles = "Admin")]
        [HttpDelete("delete/{patientId}")]
        public async Task<IActionResult> Delete(int patientId, CancellationToken cancellationToken)
        {
            await _serviceManager.PatientService.DeleteAsync(patientId, cancellationToken);
            return NoContent();
        }

        [HttpPost("create")]
        public async Task<IActionResult> Create([FromBody] PatientCreateDto patientDto, CancellationToken cancellationToken)
        {
            var response = await _serviceManager.PatientService.CreateAsync(patientDto, cancellationToken);
            return Ok(response);
        }

        [Authorize]
        [HttpGet("details/{patientId}")]
        public async Task<IActionResult> GetPatientById(int patientId, CancellationToken cancellationToken)
        {
            var response = await _serviceManager.PatientService.GetByIdAsync(patientId, cancellationToken);
            return Ok(response);
        }

        [Authorize]
        [HttpPut("update/{patientId}")]
        public async Task<IActionResult> UpdatePatient(int patientId, [FromBody] PatientUpdateDto patientDto, CancellationToken cancellationToken)
        {
            var response = await _serviceManager.PatientService.UpdateAsync(patientId, patientDto, cancellationToken);
            return Ok(response);
        }
    }
}
