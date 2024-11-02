using Domain.Repositories;
using Domain.Repositories.Common;

namespace Persistence.Repositories;

internal sealed class UnitOfWork(DataContext dbContext) : IUnitOfWork
{
    public object EmployeeRepository => throw new NotImplementedException();

    public Task<int> SaveChangesAsync(CancellationToken cancellationToken = default) => dbContext.SaveChangesAsync(cancellationToken);
}