namespace Services.Abstractions;

public interface IPatientService
{
    Task<IEnumerable<PatientDto>> GetAll(CancellationToken cancellationToken = default);

    Task<PatientDto> GetById(int patientId, CancellationToken cancellationToken = default);

    Task Delete(int patientId, CancellationToken cancellationToken = default);

    Task<GeneralResponseDto> Create(PatientCreateDto patientDto, CancellationToken cancellationToken = default);

    Task<GeneralResponseDto> Update(int patientId, PatientUpdateDto patientDto, CancellationToken cancellationToken = default);
}