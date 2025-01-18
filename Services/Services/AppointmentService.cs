using Domain.Repositories.Common;
using Microsoft.EntityFrameworkCore;
using Persistence.Repositories;
using Services.Abstractions;

namespace Services
{
    public class AppointmentService : IAppointmentService
    {
        private readonly IRepositoryManager _repositoryManager;

        public AppointmentService(IRepositoryManager repositoryManager)
        {
            _repositoryManager = repositoryManager;
        }

        public async Task<GeneralResponseDto> Create(AppointmentCreateDto appointmentDto, CancellationToken cancellationToken = default)
        {
            try
            {
                var appointment = appointmentDto.Adapt<Appointment>();
                _repositoryManager.AppointmentRepository.CreateAppointment(appointment);
                var rowsAffected = await _repositoryManager.UnitOfWork.SaveChangesAsync(cancellationToken);
                if (rowsAffected != 1)
                {
                    return new GeneralResponseDto
                    {
                        IsSuccess = false,
                        Message = "Error!"
                    };
                }

                return new GeneralResponseDto { Data = appointment.AppointmentId, Message = "Success!" };
            }
            catch (Exception ex)
            {
                return new GeneralResponseDto
                {
                    IsSuccess = false,
                    Message = ex.Message
                };
            }
        }

        public async Task Delete(int appointmentId, CancellationToken cancellationToken = default)
        {
            var appointment = await _repositoryManager.AppointmentRepository.GetById(appointmentId, cancellationToken);
            _repositoryManager.AppointmentRepository.DeleteAppointment(appointment, cancellationToken);
            await _repositoryManager.UnitOfWork.SaveChangesAsync(cancellationToken);
        }

        public async Task<IEnumerable<AppointmentDto>> GetAll(CancellationToken cancellationToken = default)
        {
            var appointments = await _repositoryManager.AppointmentRepository.GetAll(cancellationToken);
            return appointments.Adapt<IEnumerable<AppointmentDto>>();

        }

            public async Task<AppointmentDto> GetById(int appointmentId, CancellationToken cancellationToken = default)
        {
            var appointment = await _repositoryManager.AppointmentRepository.GetById(appointmentId, cancellationToken);
            return appointment.Adapt<AppointmentDto>();
        }

        public async Task<GeneralResponseDto> Update(int appointmentId, AppointmentUpdateDto appointmentDto, CancellationToken cancellationToken = default)
        {
            try
            {
                var existingAppointment = await _repositoryManager.AppointmentRepository.GetById(appointmentId, cancellationToken);
                if (existingAppointment == null)
                    return new GeneralResponseDto { IsSuccess = false, Message = "Appointment not found." };

                appointmentDto.Adapt(existingAppointment);

                _repositoryManager.AppointmentRepository.UpdateAppointment(existingAppointment);
                var res = await _repositoryManager.UnitOfWork.SaveChangesAsync(cancellationToken);
                if (res != 1)
                    return new GeneralResponseDto { IsSuccess = false };

                return new GeneralResponseDto { Data = existingAppointment.AppointmentId, Message = "Success!" };
            }
            catch (Exception ex)
            {
                return new GeneralResponseDto
                {
                    IsSuccess = false,
                    Message = ex.Message
                };
            }
        }
    }
}
