using Domain.Entities;
using Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Persistence.Repositories
{
    public class PatientRepository(DataContext dataContext) : RepositoryBase<Patient>(dataContext), IPatientRepository
    {
        public async Task CreatePatient(Patient Patient)
        {
            Create(Patient);
            await SaveChangesAsync();
        }

        public async Task DeletePatient(Patient Patient)
        {
            Delete(Patient);
            await SaveChangesAsync();
        }

        public async Task UpdatePatient(Patient Patient)
        {
            Update(Patient);
            await SaveChangesAsync();
        }

        public async Task<IEnumerable<Patient>> GetAllAsync(CancellationToken cancellationToken = default)
        {
            return await FindAll().ToListAsync(cancellationToken);
        }

        public async Task<Patient?> GetByIdAsync(int PatientId, CancellationToken cancellationToken = default)
        {
            return await FindByCondition(Patient => Patient.Id == PatientId)
                .FirstOrDefaultAsync(cancellationToken);
        }

        private async Task SaveChangesAsync()
        {
            await dataContext.SaveChangesAsync();
        }
    }
}
