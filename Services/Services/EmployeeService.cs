using Domain.Repositories.Common;

namespace Services
{
    public class EmployeeService(IRepositoryManager repositoryManager) : IEmployeeService
    {
        public async Task<GeneralResponseDto> Create(EmployeeCreateDto employeeDto, CancellationToken cancellationToken = default)
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
                        Message = "Error!"
                    };
                }

                return new GeneralResponseDto { Data = employee.EmployeeId, Message = "Success!" };
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

                return new GeneralResponseDto { Data = existingEmployee.EmployeeId, Message = "Success!" };
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