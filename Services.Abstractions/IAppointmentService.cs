namespace Services.Abstractions;

public interface IAppointmentService
{
    Task<IEnumerable<AppointmentDto>> GetAll(CancellationToken cancellationToken = default);

    Task<AppointmentDto> GetById(int appointmentId, CancellationToken cancellationToken = default);

    Task Delete(int appointmentId, CancellationToken cancellationToken = default);

    Task<GeneralResponseDto> Create(AppointmentCreateDto appointmentDto, CancellationToken cancellationToken = default);

    Task<GeneralResponseDto> Update(int appointmentId, AppointmentUpdateDto appointmentDto, CancellationToken cancellationToken = default);
}