using Contract.Account;
using Contract;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Services.Abstractions
{
    public interface IPatientService
    {
        Task<GeneralResponseDto> CreatePatient(PatientCreateDto patientDto, CancellationToken cancellationToken = default);
        Task<GeneralResponseDto> UpdatePatient(string patientId, PatientUpdateDto patientDto, CancellationToken cancellationToken = default);
        Task<GeneralResponseDto> DeletePatient(string patientId, CancellationToken cancellationToken = default);
        Task<PatientDto> GetPatientById(string patientId, CancellationToken cancellationToken = default);
        Task<IEnumerable<PatientDto>> GetAllPatients(CancellationToken cancellationToken = default);
    }
}
