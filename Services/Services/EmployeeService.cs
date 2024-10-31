using Contract;
using Contract.Account;
using Domain.Entities;
using Domain.Repositories;
using Domain.Repositories.Common;
using Mapster;
using Services.Abstractions;

namespace Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IRepositoryManager _repositoryManager;

        public EmployeeService(IRepositoryManager repositoryManager)
        {
            _repositoryManager = repositoryManager;
        }

        public async Task<GeneralResponseDto> Create(EmployeeCreateDto employeeDto, CancellationToken cancellationToken = default)
        {
            try
            {
                var employee = employeeDto.Adapt<Employee>();
                _repositoryManager.EmployeeRepository.CreateEmployee(employee);
                var rowsAffected = await _repositoryManager.UnitOfWork.SaveChangesAsync(cancellationToken);
                if (rowsAffected != 1)
                {
                    return new GeneralResponseDto
                    {
                        IsSuccess = false,
                        Message = "Error while creating employee!"
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
            var employee = await _repositoryManager.EmployeeRepository.GetByIdAsync(employeeId, cancellationToken); // Ispravljeno
            if (employee != null)
            {
                await _repositoryManager.EmployeeRepository.DeleteEmployee(employee, cancellationToken);
                await _repositoryManager.UnitOfWork.SaveChangesAsync(cancellationToken);
            }
        }

        public async Task<IEnumerable<EmployeeDto>> GetAll(CancellationToken cancellationToken = default)
        {
            var employees = await _repositoryManager.EmployeeRepository.GetAllAsync(cancellationToken); // Ispravljeno
            return employees.Adapt<IEnumerable<EmployeeDto>>();
        }

        public async Task<EmployeeDto> GetById(int employeeId, CancellationToken cancellationToken = default)
        {
          
            var employee = await _repositoryManager.EmployeeRepository.GetByIdAsync(employeeId, cancellationToken);
            return employee.Adapt<EmployeeDto>();
        }



        public async Task<GeneralResponseDto> Update(int employeeId, EmployeeUpdateDto employeeDto, CancellationToken cancellationToken = default)
        {
            try
            {
                var existingEmployee = await _repositoryManager.EmployeeRepository.GetByIdAsync(employeeId, cancellationToken);
                if (existingEmployee == null)
                    return new GeneralResponseDto { IsSuccess = false, Message = "Employee not found." };

                employeeDto.Adapt(existingEmployee);

                _repositoryManager.EmployeeRepository.UpdateEmployee(existingEmployee);
                var res = await _repositoryManager.UnitOfWork.SaveChangesAsync(cancellationToken);
                if (res != 1)
                    return new GeneralResponseDto { IsSuccess = false };

                return new GeneralResponseDto { Message = "Employee updated successfully!" };
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
