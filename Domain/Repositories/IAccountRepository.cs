using Domain.Entities;
using Domain.Repositories.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Repositories
{
    public interface IAccountRepository : IRepositoryBase <Account>
    {
        Task<IEnumerable<Account>> GetAll(CancellationToken cancellationToken = default);

        Task<Account> GetById(string accountId, CancellationToken cancellationToken = default);
    }
}
