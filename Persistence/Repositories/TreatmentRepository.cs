using Domain.Repositories;

namespace Persistence.Repositories
{
    public class TreatmentRepository(DataContext dataContext) : RepositoryBase<Treatment>(dataContext), ITreatmentRepository
    {
        public void CreateTreatment(Treatment treatment, CancellationToken cancellationToken = default) => Create(treatment);

        public void DeleteTreatment(Treatment treatment, CancellationToken cancellationToken = default) => Delete(treatment);

        public void UpdateTreatment(Treatment treatment, CancellationToken cancellationToken = default) => Update(treatment);

        public async Task<IEnumerable<Treatment>> GetAll(CancellationToken cancellationToken = default)
        {
            return await FindAll().ToListAsync(cancellationToken);
        }

        public async Task<Treatment> GetById(int treatmentId, CancellationToken cancellationToken = default)
        {
            return await FindByCondition(t => t.TreatmentId == treatmentId)
                .FirstOrDefaultAsync(cancellationToken);
        }


    }
}