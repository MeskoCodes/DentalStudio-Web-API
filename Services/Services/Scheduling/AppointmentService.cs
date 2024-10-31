using Contract;
using Contract.Scheduling;
using Domain.Entities;
using Domain.Entities.Scheduling;
using Domain.Repositories;
using Domain.Repositories.Common;
using Mapster;
using Services.Abstractions;
using Services.Abstractions.Scheduling;

namespace Services.Scheduling

{
    public class AppointmentService(IRepositoryManager repositoryManager) : IAppointmentService
    {
        public async Task<GeneralResponseDto> Create(AppointmentCreateDto appointmentDto, CancellationToken cancellationToken = default)
        {
            try
            {
                var appointment = appointmentDto.Adapt<Appointment>();
                repositoryManager.AppointmentRepository.CreateAppointment(appointment);
                var rowsAffected = await repositoryManager.UnitOfWork.SaveChangesAsync(cancellationToken);
                if (rowsAffected != 1)
                {
                    return new GeneralResponseDto
                    {
                        IsSuccess = false,
                        Message = "Error!"
                    };
                }

                return new GeneralResponseDto { Message = "Success!" };
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

        public Task<GeneralResponseDto> CreateAppointment(AppointmentCreateDto appointmentDto, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<GeneralResponseDto> DeleteAppointment(string appointmentId, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<AppointmentDto>> GetAllAppointments(CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<AppointmentDto> GetAppointmentById(string appointmentId, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<GeneralResponseDto> UpdateAppointment(string appointmentId, AppointmentUpdateDto appointmentDto, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        // Implement other methods (Delete, GetAll, GetById, Update) similarly
    }
}
