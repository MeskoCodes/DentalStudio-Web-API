using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Domain.Entities;
using Domain.Repositories;
using Services.Abstractions;
using Contract;
using Contract.Account;

namespace Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IEmployeeRepository _EmployeeRepository;

        public EmployeeService(IEmployeeRepository EmployeeRepository)
        {
            _EmployeeRepository = EmployeeRepository;
        }

        public async Task<IEnumerable<EmployeeDto>> GetAllAsync(CancellationToken cancellationToken)
        {
            var Employees = await _EmployeeRepository.GetAllAsync(cancellationToken);
            // Map entities to DTOs
            return Employees.Select(Employee => new EmployeeDto
            {
                // Map properties here
            });
        }

        public async Task<EmployeeDto> GetByIdAsync(int EmployeeId, CancellationToken cancellationToken)
        {
            var Employee = await _EmployeeRepository.GetByIdAsync(EmployeeId, cancellationToken);
            // Map to DTO
            return Employee != null ? new EmployeeDto
            {
                // Map properties here
            } : null;
        }

        public async Task CreateAsync(EmployeeCreateDto EmployeeDto, CancellationToken cancellationToken)
        {
            var Employee = new Employee
            {
                // Map properties from DTO to entity here
            };
            await _EmployeeRepository.CreateEmployee(Employee);
        }

        public async Task UpdateAsync(int EmployeeId, EmployeeUpdateDto EmployeeDto, CancellationToken cancellationToken)
        {
            var Employee = await _EmployeeRepository.GetByIdAsync(EmployeeId, cancellationToken);
            if (Employee != null)
            {
                // Map properties from DTO to entity here
                await _EmployeeRepository.UpdateEmployee(Employee);
            }
        }

        public async Task DeleteAsync(int EmployeeId, CancellationToken cancellationToken)
        {
            var Employee = await _EmployeeRepository.GetByIdAsync(EmployeeId, cancellationToken);
            if (Employee != null)
            {
                await _EmployeeRepository.DeleteEmployee(Employee, cancellationToken);
            }
        }
    }
}
