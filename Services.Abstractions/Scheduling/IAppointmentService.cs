using Contract.Scheduling;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Services.Abstractions
{
    public interface IAppointmentService
    {
        Task<IEnumerable<AppointmentDto>> GetAllAsync(CancellationToken cancellationToken);
        Task<AppointmentDto> GetByIdAsync(int appointmentId, CancellationToken cancellationToken);
        Task CreateAsync(AppointmentCreateDto appointmentDto, CancellationToken cancellationToken);
        Task UpdateAsync(int appointmentId, AppointmentUpdateDto appointmentDto, CancellationToken cancellationToken);
        Task DeleteAsync(int appointmentId, CancellationToken cancellationToken);
    }
}
