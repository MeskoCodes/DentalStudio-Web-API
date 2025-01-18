using Domain.Entities;
using Domain.Repositories.Common;

namespace Domain.Repositories;

public interface IEmployeeRepository : IRepositoryBase<Employee>
{
    Task<IEnumerable<Employee>> GetAll(CancellationToken cancellationToken = default);

    Task<Employee> GetById(int employeeId, CancellationToken cancellationToken = default);

    void CreateEmployee(Employee employee, CancellationToken cancellationToken = default);

    void DeleteEmployee(Employee employee, CancellationToken cancellationToken = default);

    void UpdateEmployee(Employee employee, CancellationToken cancellationToken = default);
}