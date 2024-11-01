using Contract.Account;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Services.Abstractions
{
    public interface IPatientService
    {
        Task<IEnumerable<PatientDto>> GetAllAsync(CancellationToken cancellationToken);
        Task<PatientDto> GetByIdAsync(int patientId, CancellationToken cancellationToken);
        Task CreateAsync(PatientCreateDto patientDto, CancellationToken cancellationToken);
        Task UpdateAsync(int patientId, PatientUpdateDto patientDto, CancellationToken cancellationToken);
        Task DeleteAsync(int patientId, CancellationToken cancellationToken);
    }
}
