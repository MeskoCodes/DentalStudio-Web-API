using Domain.Repositories;

namespace Persistence.Repositories
{
    public class PatientRepository(DataContext dataContext) : RepositoryBase<Patient>(dataContext), IPatientRepository
    {
        public void CreatePatient(Patient patient, CancellationToken cancellationToken = default) => Create(patient);

        public void DeletePatient(Patient patient, CancellationToken cancellationToken = default) => Delete(patient);

        public void UpdatePatient(Patient patient, CancellationToken cancellationToken = default) => Update(patient);

        public async Task<IEnumerable<Patient>> GetAll(CancellationToken cancellationToken = default)
        {
            return await FindAll().ToListAsync(cancellationToken);
        }

        public async Task<Patient> GetById(int patientId, CancellationToken cancellationToken = default)
        {
            return await FindByCondition(p => p.PatientId == patientId)
                .FirstOrDefaultAsync(cancellationToken);
        }


    }
}