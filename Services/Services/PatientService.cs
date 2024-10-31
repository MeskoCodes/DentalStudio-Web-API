using Contract;
using Contract.Account;
using Domain.Entities;
using Domain.Repositories;
using Domain.Repositories.Common;
using Mapster;
using Services.Abstractions;

namespace Services
{
    public class PatientService(IRepositoryManager repositoryManager) : IPatientService
    {
        public async Task<GeneralResponseDto> Create(PatientCreateDto patientDto, CancellationToken cancellationToken = default)
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

        public Task<GeneralResponseDto> CreatePatient(PatientCreateDto patientDto, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<GeneralResponseDto> DeletePatient(string patientId, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<PatientDto>> GetAllPatients(CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<PatientDto> GetPatientById(string patientId, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<GeneralResponseDto> UpdatePatient(string patientId, PatientUpdateDto patientDto, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        // Implement other methods (Delete, GetAll, GetById, Update) similarly
    }
}
