using Domain.Repositories;
using Domain.Repositories.Common;
using Persistence.Repositories;

namespace Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IEmployeeRepository _employeeRepository;
        private readonly IRepositoryManager _repositoryManager;

        public EmployeeService(IRepositoryManager repositoryManager)
        {
            _repositoryManager = repositoryManager;
        }


        public async Task<IEnumerable<EmployeeDto>> GetAllAsync(CancellationToken cancellationToken)
        {
            var employee = await _repositoryManager.EmployeeRepository.GetAllAsync(cancellationToken);
            return employee.Adapt<IEnumerable<EmployeeDto>>();
        }

        public Task<EmployeeDto> GetByIdAsync(int employeeId, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
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
