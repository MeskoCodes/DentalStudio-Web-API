using Domain.Entities;
using Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Persistence.Repositories
{
    public class TreatmentRepository(DataContext dataContext) : RepositoryBase<Treatment>(dataContext), ITreatmentRepository
    {
        public async Task CreateTreatment(Treatment treatment)
        {
            Create(treatment);
            await SaveChangesAsync();
        }

        public async Task DeleteTreatment(Treatment treatment)
        {
            Delete(treatment);
            await SaveChangesAsync();
        }

        public async Task UpdateTreatment(Treatment treatment)
        {
            Update(treatment);
            await SaveChangesAsync();
        }

        public async Task<IEnumerable<Treatment>> GetAllAsync(CancellationToken cancellationToken = default)
        {
            return await FindAll().ToListAsync(cancellationToken);
        }

        public async Task<Treatment?> GetByIdAsync(int treatmentId, CancellationToken cancellationToken = default)
        {
            return await FindByCondition(treatment => treatment.Id == treatmentId)
                .FirstOrDefaultAsync(cancellationToken);
        }

        private async Task SaveChangesAsync()
        {
            await dataContext.SaveChangesAsync();
        }
    }
}
