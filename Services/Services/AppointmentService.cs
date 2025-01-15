using Domain.Repositories.Common;
using Contract;
using Domain.Entities;

namespace Services
{
    public class AppointmentService : IAppointmentService
    {
        private readonly IRepositoryManager _repositoryManager;

        public AppointmentService(IRepositoryManager repositoryManager)
        {
            _repositoryManager = repositoryManager;
        }

        public async Task<IEnumerable<AppointmentDto>> GetAllAsync(CancellationToken cancellationToken)
        {
            var appointment = await _repositoryManager.AppointmentRepository.GetAllAsync(cancellationToken);
            return appointment.Adapt<IEnumerable<AppointmentDto>>();
        }

        public async Task<AppointmentDto> GetById(int appointmentId, CancellationToken cancellationToken)
        {
            var appointment = await _repositoryManager.AppointmentRepository.GetByIdAsync(appointmentId, cancellationToken);
            return appointment.Adapt<AppointmentDto>();
        }

        public async Task CreateAsync(AppointmentCreateDto appointmentDto, CancellationToken cancellationToken)
        {
            var appointment = appointmentDto.Adapt<Appointment>();
            _repositoryManager.AppointmentRepository.CreateAppointment(appointment);
            await _repositoryManager.UnitOfWork.SaveChangesAsync(cancellationToken);
        }

        public async Task UpdateAsync(int appointmentId, AppointmentUpdateDto appointmentDto, CancellationToken cancellationToken)
        {
            var appointment= await _repositoryManager.AppointmentRepository.GetByIdAsync(appointmentId, cancellationToken);
            appointment.PatientId= appointmentDto.PatientId;
            appointment.AppointmentDate = appointmentDto.AppointmentDate;
            appointment.AppointmentTime = appointmentDto.AppointmentTime;
            appointment.Status = appointmentDto.Status;

            await _repositoryManager.UnitOfWork.SaveChangesAsync(cancellationToken);
        }


        public async Task DeleteAsync(int appointmentId, CancellationToken cancellationToken)
        {
            var appointment = await _repositoryManager.AppointmentRepository.GetByIdAsync(appointmentId, cancellationToken);
            _repositoryManager.AppointmentRepository.DeleteAppointment(appointment);
            await _repositoryManager.UnitOfWork.SaveChangesAsync(cancellationToken);
        }
        public Task<AppointmentDto> GetByIdAsync(int appointmentId, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

    }
}
