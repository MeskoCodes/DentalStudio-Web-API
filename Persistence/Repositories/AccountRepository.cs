using Domain.Entities;
using Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Persistence.Repositories
{
    public sealed class AccountRepository(DataContext dataContext) : RepositoryBase<Account>(dataContext), IAccountRepository
    {
        public async Task<IEnumerable<Account>> GetAll(CancellationToken cancellationToken = default)
        {
            return await FindAll().ToListAsync(cancellationToken);
        }

        public async Task<Account> GetById(string accountId, CancellationToken cancellationToken = default)
        {
            return await FindByCondition(account => account.Id == accountId)
                .FirstOrDefaultAsync(cancellationToken);
        }
    }
}