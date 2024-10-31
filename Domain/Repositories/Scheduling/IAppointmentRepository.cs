using Domain.Entities.Scheduling;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Repositories.Scheduling
{
    public interface IAppointmentRepository
    {
        Task<Appointment> GetByIdAsync(int appointmentId, CancellationToken cancellationToken = default);
        Task<IEnumerable<Appointment>> GetAllAsync(CancellationToken cancellationToken = default);
        void CreateAppointment(Appointment appointment);
        void UpdateAppointment(Appointment appointment);
        void DeleteAppointment(Appointment appointment);
    }
}
