using Contract.Scheduling;
using Contract;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Services.Abstractions.Scheduling
{
    public interface IAppointmentService
    {
        Task<GeneralResponseDto> CreateAppointment(AppointmentCreateDto appointmentDto, CancellationToken cancellationToken = default);
        Task<GeneralResponseDto> UpdateAppointment(string appointmentId, AppointmentUpdateDto appointmentDto, CancellationToken cancellationToken = default);
        Task<GeneralResponseDto> DeleteAppointment(string appointmentId, CancellationToken cancellationToken = default);
        Task<AppointmentDto> GetAppointmentById(string appointmentId, CancellationToken cancellationToken = default);
        Task<IEnumerable<AppointmentDto>> GetAllAppointments(CancellationToken cancellationToken = default);
    }
}
