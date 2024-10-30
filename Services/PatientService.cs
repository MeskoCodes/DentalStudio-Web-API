using Contract; // Uveri se da ovde imaš sve potrebne DTO-eve
using Domain.Entities;
using Domain.Repositories;
using Mapster;
using Services.Abstractions;

namespace Services
{
    public class PatientService : IPatientService
    {
        private readonly IRepositoryManager repositoryManager;

        public PatientService(IRepositoryManager repositoryManager)
        {
            this.repositoryManager = repositoryManager;
        }

        public async Task<GeneralResponseDto> Create(PatientDto patientDto, CancellationToken cancellationToken = default)
        {
            try
            {
                var patient = patientDto.Adapt<Patient>();
                repositoryManager.PatientRepository.CreatePatient(patient);
                var rowsAffected = await repositoryManager.UnitOfWork.SaveChangesAsync(cancellationToken);
                if (rowsAffected != 1)
                {
                    return new GeneralResponseDto
                    {
                        IsSuccess = false,
                        Message = "Error creating patient!"
                    };
                }

                return new GeneralResponseDto { Message = "Patient created successfully!" };
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

        public async Task Delete(int patientId, CancellationToken cancellationToken = default)
        {
            var patient = await repositoryManager.PatientRepository.GetById(patientId, cancellationToken);
            repositoryManager.PatientRepository.DeletePatient(patient, cancellationToken);
            await repositoryManager.UnitOfWork.SaveChangesAsync(cancellationToken);
        }

        public async Task<IEnumerable<PatientDto>> GetAll(CancellationToken cancellationToken = default)
        {
            var patients = await repositoryManager.PatientRepository.GetAll(cancellationToken);
            return patients.Adapt<IEnumerable<PatientDto>>();
        }

        public async Task<PatientDto> GetById(int patientId, CancellationToken cancellationToken = default)
        {
            var patient = await repositoryManager.PatientRepository.GetById(patientId, cancellationToken);
            return patient.Adapt<PatientDto>();
        }

        public async Task<GeneralResponseDto> Update(int patientId, PatientUpdateDto patientDto, CancellationToken cancellationToken = default)
        {
            try
            {
                var existingPatient = await repositoryManager.PatientRepository.GetById(patientId, cancellationToken);
                if (existingPatient == null)
                    return new GeneralResponseDto { IsSuccess = false, Message = "Patient not found." };

                patientDto.Adapt(existingPatient);

                repositoryManager.PatientRepository.UpdatePatient(existingPatient);
                var res = await repositoryManager.UnitOfWork.SaveChangesAsync(cancellationToken);
                if (res != 1)
                    return new GeneralResponseDto { IsSuccess = false };

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
    }
}
