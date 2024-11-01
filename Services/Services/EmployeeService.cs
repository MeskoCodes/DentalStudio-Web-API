using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Domain.Entities;
using Domain.Repositories;
using Services.Abstractions;
using Contract;
using Contract.Account;
using Domain.Repositories.Common;

namespace Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IEmployeeRepository _employeeRepository;
        private IRepositoryManager repositoryManager;

        public EmployeeService(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }

        public EmployeeService(IRepositoryManager repositoryManager)
        {
            this.repositoryManager = repositoryManager;
        }

        public async Task<IEnumerable<EmployeeDto>> GetAllAsync(CancellationToken cancellationToken)
        {
            var employees = await _employeeRepository.GetAllAsync(cancellationToken);
            // Map entities to DTOs
            return employees.Select(employee => new EmployeeDto
            {
                // Map properties here
            });
        }

        public async Task<EmployeeDto> GetByIdAsync(int employeeId, CancellationToken cancellationToken)
        {
            var employee = await _employeeRepository.GetByIdAsync(employeeId, cancellationToken);
            // Map to DTO
            return employee != null ? new EmployeeDto
            {
                // Map properties here
            } : null;
        }

        public async Task CreateAsync(EmployeeCreateDto employeeDto, CancellationToken cancellationToken)
        {
            var employee = new Employee
            {
                // Map properties from DTO to entity here
            };
            await _employeeRepository.CreateEmployee(employee);
        }

        public async Task UpdateAsync(int employeeId, EmployeeUpdateDto employeeDto, CancellationToken cancellationToken)
        {
            var employee = await _employeeRepository.GetByIdAsync(employeeId, cancellationToken);
            if (employee != null)
            {
                // Map properties from DTO to entity here
                await _employeeRepository.UpdateEmployee(employee);
            }
        }

        public async Task DeleteAsync(int employeeId, CancellationToken cancellationToken)
        {
            var employee = await _employeeRepository.GetByIdAsync(employeeId, cancellationToken);
            if (employee != null)
            {
                await _employeeRepository.DeleteEmployee(employee, cancellationToken);
            }
        }
    }
}
