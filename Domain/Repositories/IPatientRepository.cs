using Domain.Entities;
using Domain.Repositories.Common;

namespace Domain.Repositories;

public interface IPatientRepository : IRepositoryBase<Patient>
{
    Task<IEnumerable<Patient>> GetAll(CancellationToken cancellationToken = default);

    Task<Patient> GetById(int patientId, CancellationToken cancellationToken = default);

    void CreatePatient(Patient patient, CancellationToken cancellationToken = default);

    void DeletePatient(Patient patient, CancellationToken cancellationToken = default);

    void UpdatePatient(Patient patient, CancellationToken cancellationToken = default);
}