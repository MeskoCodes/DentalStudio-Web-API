using Contract;
using Microsoft.AspNetCore.Mvc;
using Services.Abstractions;

namespace Presentation.Controllers
{
    [ApiController]
    [Route("api/patients")]
    public class PatientController(IServiceManager serviceManager) : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> GetAllPatients(CancellationToken cancellationToken)
        {
            var response = await serviceManager.PatientService.GetAll(cancellationToken);
            return Ok(response);
        }

        [HttpDelete("{patientId}")]
        public async Task<IActionResult> Delete(int patientId, CancellationToken cancellationToken)
        {
            await serviceManager.PatientService.Delete(patientId, cancellationToken);
            return NoContent();
        }

        [HttpPost("create")]
        public async Task<IActionResult> Create([FromBody] PatientCreateDto patientDto, CancellationToken cancellationToken)
        {
            var response = await serviceManager.PatientService.Create(patientDto, cancellationToken);
            return Ok(response);
        }

        [HttpGet("details/{patientId}")]
        public async Task<IActionResult> GetPatientById(int patientId, CancellationToken cancellationToken)
        {
            var response = await serviceManager.PatientService.GetById(patientId, cancellationToken);
            return Ok(response);
        }


        [HttpPut("update/{patientId}")]
        public async Task<IActionResult> UpdatePatient(int patientId, [FromBody] PatientUpdateDto patientDto, CancellationToken cancellationToken)
        {
            var response = await serviceManager.PatientService.Update(patientId, patientDto, cancellationToken);
            return Ok(response);
        }
    }
}