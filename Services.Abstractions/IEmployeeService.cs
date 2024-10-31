using Contract;
using Contract.Account;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Abstractions;

public interface IEmployeeService
{
    Task<IEnumerable<EmployeeDto>> GetAll(CancellationToken cancellationToken = default);
    Task<EmployeeDto> GetById(int employeeId, CancellationToken cancellationToken = default);
    Task Delete(int employeeId, CancellationToken cancellationToken = default);
    Task<GeneralResponseDto> Create(EmployeeCreateDto employeeDto, CancellationToken cancellationToken = default);
    Task<GeneralResponseDto> Update(int employeeId, EmployeeUpdateDto employeeDto, CancellationToken cancellationToken = default);
}
