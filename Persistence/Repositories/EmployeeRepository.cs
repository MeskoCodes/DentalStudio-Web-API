using Domain.Entities;
using Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Persistence.Repositories
{
    public class EmployeeRepository(DataContext dataContext) : RepositoryBase<Employee>(dataContext), IEmployeeRepository
    {
        public async Task CreateEmployee(Employee Employee)
        {
            Create(Employee);
            await SaveChangesAsync();
        }

        public async Task DeleteEmployee(Employee Employee, CancellationToken cancellationToken)
        {
            Delete(Employee);
            await SaveChangesAsync();
        }

        public async Task UpdateEmployee(Employee Employee)
        {
            Update(Employee);
            await SaveChangesAsync();
        }

        public async Task<IEnumerable<Employee>> GetAllAsync(CancellationToken cancellationToken = default)
        {
            return await FindAll().ToListAsync(cancellationToken);
        }

        public async Task<Employee?> GetByIdAsync(int EmployeeId, CancellationToken cancellationToken = default)
        {
            return await FindByCondition(Employee => EmployeeId == EmployeeId)
                .FirstOrDefaultAsync(cancellationToken);
        }

        private async Task SaveChangesAsync()
        {
            await dataContext.SaveChangesAsync();
        }
    }
}
