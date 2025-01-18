using Domain.Repositories;

namespace Persistence.Repositories
{
    public class EmployeeRepository(DataContext dataContext) : RepositoryBase<Employee>(dataContext), IEmployeeRepository
    {
        public void CreateEmployee(Employee employee, CancellationToken cancellationToken = default) => Create(employee);

        public void DeleteEmployee(Employee employee, CancellationToken cancellationToken = default) => Delete(employee);

        public void UpdateEmployee(Employee employee, CancellationToken cancellationToken = default) => Update(employee);

        public async Task<IEnumerable<Employee>> GetAll(CancellationToken cancellationToken = default)
        {
            return await FindAll().ToListAsync(cancellationToken);
        }

        public async Task<Employee> GetById(int employeeId, CancellationToken cancellationToken = default)
        {
            return await FindByCondition(e => e.EmployeeId == employeeId)
                .FirstOrDefaultAsync(cancellationToken);
        }

   
    }
}