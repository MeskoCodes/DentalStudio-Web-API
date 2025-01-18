using Domain.Repositories.Common;

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

                return new GeneralResponseDto { Data = patient.PatientId, Message = "Success!" };
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

                return new GeneralResponseDto { Data = existingPatient.PatientId, Message = "Success!" };
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