using Contract.Account;
using Contract;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Services.Abstractions
{
    public interface ITreatmentService
    {
        Task<GeneralResponseDto> CreateTreatment(TreatmentCreateDto treatmentDto, CancellationToken cancellationToken = default);
        Task<GeneralResponseDto> UpdateTreatment(string treatmentId, TreatmentUpdateDto treatmentDto, CancellationToken cancellationToken = default);
        Task<GeneralResponseDto> DeleteTreatment(string treatmentId, CancellationToken cancellationToken = default);
        Task<TreatmentDto> GetTreatmentById(string treatmentId, CancellationToken cancellationToken = default);
        Task<IEnumerable<TreatmentDto>> GetAllTreatments(CancellationToken cancellationToken = default);
    }
}
