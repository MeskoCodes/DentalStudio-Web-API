using Domain.Entities;
using Domain.Repositories.Common;

namespace Domain.Repositories;

public interface IAppointmentRepository : IRepositoryBase<Appointment>
{
    Task<IEnumerable<Appointment>> GetAll(CancellationToken cancellationToken = default);

    Task<Appointment> GetById(int appointmentId, CancellationToken cancellationToken = default);

    void CreateAppointment(Appointment appointment, CancellationToken cancellationToken = default);

    void DeleteAppointment(Appointment appointment, CancellationToken cancellationToken = default);

    void UpdateAppointment(Appointment appointment, CancellationToken cancellationToken = default);
}