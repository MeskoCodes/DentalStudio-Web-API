using Domain.Entities.Scheduling;
using Domain.Repositories.Scheduling;
using Microsoft.EntityFrameworkCore;

namespace Persistence.Repositories.Scheduling
{
    public class AppointmentRepository(DataContext dataContext) : RepositoryBase<Appointment>(dataContext), IAppointmentRepository
    {
        public void CreateAppointment(Appointment appointment) => Create(appointment);

        public void DeleteAppointment(Appointment appointment) => Delete(appointment);

        public void UpdateAppointment(Appointment appointment) => Update(appointment);

        public async Task<IEnumerable<Appointment>> GetAllAsync(CancellationToken cancellationToken = default)
        {
            return await FindAll().ToListAsync(cancellationToken);
        }

        public async Task<Appointment?> GetByIdAsync(int appointmentId, CancellationToken cancellationToken = default)
        {
            return await FindByCondition(appointment => appointment.AppointmentId == appointmentId)
                .FirstOrDefaultAsync(cancellationToken);
        }
    }
}
