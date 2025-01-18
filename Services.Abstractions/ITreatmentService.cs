namespace Services.Abstractions;

public interface ITreatmentService
{
    Task<IEnumerable<TreatmentDto>> GetAll(CancellationToken cancellationToken = default);

    Task<TreatmentDto> GetById(int treatmentId, CancellationToken cancellationToken = default);

    Task Delete(int treatmentId, CancellationToken cancellationToken = default);

    Task<GeneralResponseDto> Create(TreatmentCreateDto treatmentDto, CancellationToken cancellationToken = default);

    Task<GeneralResponseDto> Update(int treatmentId, TreatmentUpdateDto treatmentDto, CancellationToken cancellationToken = default);
}