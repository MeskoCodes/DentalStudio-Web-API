
using Azure;
using Domain.Repositories.Common;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Services.Abstractions;

namespace MDental.UI.Controllers
{
    [ApiController]
    [Route("api/employees")]
    public class EmployeeController : ControllerBase
    {
        private readonly IServiceManager _serviceManager;

        public EmployeeController(IServiceManager serviceManager)
        {
            _serviceManager = serviceManager;
        }

        [Authorize]
        [HttpGet]
        public async Task<IActionResult> GetAllEmployees(CancellationToken cancellationToken)
        {
            var response = await _serviceManager.EmployeeService.GetAllAsync(cancellationToken);
            return Ok(response);
        }
    

        [Authorize(Roles = "Admin")]
        [HttpDelete("delete/{employeeId}")]
        public async Task<IActionResult> Delete(int employeeId, CancellationToken cancellationToken)
        {
            await _serviceManager.EmployeeService.DeleteAsync(employeeId, cancellationToken);
            return NoContent();
        }

        [HttpPost("create")]
        public async Task<IActionResult> Create([FromBody] EmployeeCreateDto employeeDto, CancellationToken cancellationToken)
        {
            await _serviceManager.EmployeeService.CreateAsync(employeeDto, cancellationToken);
            return Ok();
        }

        [Authorize]
        [HttpGet("details/{employeeId}")]
        public async Task<IActionResult> GetEmployeeById(int employeeId, CancellationToken cancellationToken)
        {
            var response = await _serviceManager.EmployeeService.GetByIdAsync(employeeId, cancellationToken);
            return Ok(response);
        }

        [Authorize]
        [HttpPut("update/{employeeId}")]
        public async Task<IActionResult> UpdateEmployee(int employeeId, [FromBody] EmployeeUpdateDto employeeDto, CancellationToken cancellationToken)
        {
            await _serviceManager.EmployeeService.UpdateAsync(employeeId, employeeDto, cancellationToken);
            return NoContent();
        }
    }
}
