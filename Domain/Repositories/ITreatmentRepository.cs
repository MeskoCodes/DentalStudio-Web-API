using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Repositories
{
    public interface ITreatmentRepository
    {
        Task<Treatment> GetByIdAsync(int treatmentId, CancellationToken cancellationToken = default);
        Task<IEnumerable<Treatment>> GetAllAsync(CancellationToken cancellationToken = default);
        void CreateTreatment(Treatment treatment);
        void UpdateTreatment(Treatment treatment);
        void DeleteTreatment(Treatment treatment);
    }
}
