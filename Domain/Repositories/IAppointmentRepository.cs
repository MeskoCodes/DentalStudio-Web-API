using Domain.Entities;

namespace Domain.Repositories
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
