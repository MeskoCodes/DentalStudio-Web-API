using Contract; // Uveri se da ovde imaš sve potrebne DTO-eve
using Domain.Entities;
using Domain.Repositories;
using Mapster;
using Services.Abstractions;

namespace Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IRepositoryManager repositoryManager;

        public EmployeeService(IRepositoryManager repositoryManager)
        {
            this.repositoryManager = repositoryManager;
        }

        public async Task<GeneralResponseDto> Create(EmployeeDto employeeDto, CancellationToken cancellationToken = default)
        {
            try
            {
                var employee = employeeDto.Adapt<Employee>();
                repositoryManager.EmployeeRepository.CreateEmployee(employee);
                var rowsAffected = await repositoryManager.UnitOfWork.SaveChangesAsync(cancellationToken);
                if (rowsAffected != 1)
                {
                    return new GeneralResponseDto
                    {
                        IsSuccess = false,
                        Message = "Error creating employee!"
                    };
                }

                return new GeneralResponseDto { Message = "Employee created successfully!" };
            }
            catch (Exception ex)
            {
                return new GeneralResponseDto
                {
                    IsSuccess = false,
                    Message = ex.Message
                };
            }
        }

        public async Task Delete(int employeeId, CancellationToken cancellationToken = default)
        {
            var employee = await repositoryManager.EmployeeRepository.GetById(employeeId, cancellationToken);
            repositoryManager.EmployeeRepository.DeleteEmployee(employee, cancellationToken);
            await repositoryManager.UnitOfWork.SaveChangesAsync(cancellationToken);
        }

        public async Task<IEnumerable<EmployeeDto>> GetAll(CancellationToken cancellationToken = default)
        {
            var employees = await repositoryManager.EmployeeRepository.GetAll(cancellationToken);
            return employees.Adapt<IEnumerable<EmployeeDto>>();
        }

        public async Task<EmployeeDto> GetById(int employeeId, CancellationToken cancellationToken = default)
        {
            var employee = await repositoryManager.EmployeeRepository.GetById(employeeId, cancellationToken);
            return employee.Adapt<EmployeeDto>();
        }

        public async Task<GeneralResponseDto> Update(int employeeId, EmployeeUpdateDto employeeDto, CancellationToken cancellationToken = default)
        {
            try
            {
                var existingEmployee = await repositoryManager.EmployeeRepository.GetById(employeeId, cancellationToken);
                if (existingEmployee == null)
                    return new GeneralResponseDto { IsSuccess = false, Message = "Employee not found." };

                employeeDto.Adapt(existingEmployee);

                repositoryManager.EmployeeRepository.UpdateEmployee(existingEmployee);
                var res = await repositoryManager.UnitOfWork.SaveChangesAsync(cancellationToken);
                if (res != 1)
                    return new GeneralResponseDto { IsSuccess = false };

                return new GeneralResponseDto { Message = "Success!" };
            }
            catch (Exception ex)
            {
                return new GeneralResponseDto
                {
                    IsSuccess = false,
                    Message = ex.Message
                };
            }
        }
    }
}
