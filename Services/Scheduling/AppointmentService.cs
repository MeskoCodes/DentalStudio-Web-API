using Contract.Scheduling; // Pretpostavljam da je AppointmentDto ovde
using Domain.Entities;
using Domain.Repositories;
using Mapster;
using Services.Abstractions;

namespace Services.Scheduling
{
    public class AppointmentService : IAppointmentService
    {
        private readonly IRepositoryManager repositoryManager;

        public AppointmentService(IRepositoryManager repositoryManager)
        {
            this.repositoryManager = repositoryManager;
        }

        public async Task<GeneralResponseDto> Create(AppointmentDto appointmentDto, CancellationToken cancellationToken = default)
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
                        Message = "Error creating appointment!"
                    };
                }

                return new GeneralResponseDto { Message = "Appointment created successfully!" };
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

        // Implementiraj ostale metode kao što su Delete, GetAll, GetById, Update
    }
}
