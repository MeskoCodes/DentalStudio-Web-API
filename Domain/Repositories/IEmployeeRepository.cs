using Domain.Entities;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Domain.Repositories
{
    public interface IEmployeeRepository
    {
        Task<Employee> GetByIdAsync(int employeeId, CancellationToken cancellationToken = default);
        Task<IEnumerable<Employee>> GetAllAsync(CancellationToken cancellationToken = default);
        Task CreateEmployee(Employee employee); // Takođe bi mogla da bude asinkrona
        Task UpdateEmployee(Employee employee); // Takođe bi mogla da bude asinkrona
        Task DeleteEmployee(Employee employee, CancellationToken cancellationToken); // Ažurirano
    }
}
