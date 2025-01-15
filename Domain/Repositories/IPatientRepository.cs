namespace Domain.Repositories
{
    public interface IPatientRepository
    {
        Task CreatePatient(Patient Patient);
        Task DeletePatient(Patient Patient);
        Task UpdatePatient(Patient Patient);
        Task<IEnumerable<Patient>> GetAllAsync(CancellationToken cancellationToken = default);
        Task<Patient?> GetByIdAsync(int PatientId, CancellationToken cancellationToken = default);
    }
}
