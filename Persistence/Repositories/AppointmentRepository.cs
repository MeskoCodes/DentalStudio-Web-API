using Domain.Repositories;

namespace Persistence.Repositories
{
    public class AppointmentRepository(DataContext dataContext) : RepositoryBase<Appointment>(dataContext), IAppointmentRepository
    {
        public void CreateAppointment(Appointment appointment, CancellationToken cancellationToken = default) => Create(appointment);

        public void DeleteAppointment(Appointment appointment, CancellationToken cancellationToken = default) => Delete(appointment);

        public void UpdateAppointment(Appointment appointment, CancellationToken cancellationToken = default) => Update(appointment);

        public async Task<IEnumerable<Appointment>> GetAll(CancellationToken cancellationToken = default)
        {
            return await FindAll().ToListAsync(cancellationToken);
        }

        public async Task<Appointment> GetById(int appointmentId, CancellationToken cancellationToken = default)
        {
            return await FindByCondition(a => a.AppointmentId == appointmentId)
                .FirstOrDefaultAsync(cancellationToken);
        }


    }
}