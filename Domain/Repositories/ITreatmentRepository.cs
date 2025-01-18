using Domain.Entities;
using Domain.Repositories.Common;

namespace Domain.Repositories;

public interface ITreatmentRepository : IRepositoryBase<Treatment>
{
    Task<IEnumerable<Treatment>> GetAll(CancellationToken cancellationToken = default);

    Task<Treatment> GetById(int treatmentId, CancellationToken cancellationToken = default);

    void CreateTreatment(Treatment treatment, CancellationToken cancellationToken = default);

    void DeleteTreatment(Treatment treatment, CancellationToken cancellationToken = default);

    void UpdateTreatment(Treatment treatment, CancellationToken cancellationToken = default);
}