using Microsoft.AspNetCore.Mvc;
using Services.Abstractions;

namespace Presentation.Controllers
{
    [ApiController]
    [Route("api/employees")]
    public class EmployeeController(IServiceManager serviceManager) : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> GetAllEmployees(CancellationToken cancellationToken)
        {
            var response = await serviceManager.EmployeeService.GetAll(cancellationToken);
            return Ok(response);
        }

        [HttpDelete("{employeeId}")]
        public async Task<IActionResult> Delete(int employeeId, CancellationToken cancellationToken)
        {
            await serviceManager.EmployeeService.Delete(employeeId, cancellationToken);
            return NoContent();
        }

        [HttpPost("create")]
        public async Task<IActionResult> Create([FromBody] EmployeeCreateDto employeeDto, CancellationToken cancellationToken)
        {
            var response = await serviceManager.EmployeeService.Create(employeeDto, cancellationToken);
            return Ok(response);
        }

        [HttpGet("details/{employeeId}")]
        public async Task<IActionResult> GetEmployeeById(int employeeId, CancellationToken cancellationToken)
        {
            var response = await serviceManager.EmployeeService.GetById(employeeId, cancellationToken);
            return Ok(response);
        }


        [HttpPut("update/{employeeId}")]
        public async Task<IActionResult> UpdateEmployee(int employeeId, [FromBody] EmployeeUpdateDto employeeDto, CancellationToken cancellationToken)
        {
            var response = await serviceManager.EmployeeService.Update(employeeId, employeeDto, cancellationToken);
            return Ok(response);
        }
    }
}