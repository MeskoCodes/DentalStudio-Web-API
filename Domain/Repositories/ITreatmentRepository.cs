using Domain.Entities;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Domain.Repositories
{
    public interface ITreatmentRepository
    {
        Task CreateTreatment(Treatment treatment);
        Task DeleteTreatment(Treatment treatment);
        Task UpdateTreatment(Treatment treatment);
        Task<IEnumerable<Treatment>> GetAllAsync(CancellationToken cancellationToken = default);
        Task<Treatment?> GetByIdAsync(int treatmentId, CancellationToken cancellationToken = default);
    }
}
