using Domain.Repositories.Common;

namespace Services
{
    public class PatientService : IPatientService
    {
        private readonly IRepositoryManager _repositoryManager;

        public PatientService(IRepositoryManager repositoryManager)
        {
            _repositoryManager = repositoryManager;
        }

        public async Task<IEnumerable<PatientDto>> GetAllAsync(CancellationToken cancellationToken)
        {
            var patient = await _repositoryManager.PatientRepository.GetAllAsync(cancellationToken);
            return patient.Adapt<IEnumerable<PatientDto>>();
        }

        public async Task<PatientDto> GetById(int patientId, CancellationToken cancellationToken)
        {
            var patient = await _repositoryManager.PatientRepository.GetByIdAsync(patientId, cancellationToken);
            return patient.Adapt<PatientDto>();
        }

        public async Task CreateAsync(PatientCreateDto patientDto, CancellationToken cancellationToken)
        {
            var patient = patientDto.Adapt<Patient>();
            _repositoryManager.PatientRepository.CreatePatient(patient);
            await _repositoryManager.UnitOfWork.SaveChangesAsync(cancellationToken);
        }

        public async Task UpdateAsync(int patientId, PatientUpdateDto patientDto, CancellationToken cancellationToken)
        {
            var patient = await _repositoryManager.PatientRepository.GetByIdAsync(patientId, cancellationToken);
            patient.FirstName = patientDto.FirstName;
            patient.LastName = patientDto.LastName;
            patient.MobileNumber = patientDto.MobileNumber;
            patient.Email = patientDto.Email;

            await _repositoryManager.UnitOfWork.SaveChangesAsync(cancellationToken);
        }

        public async Task DeleteAsync(int patientId, CancellationToken cancellationToken)
        {
            var patient = await _repositoryManager.PatientRepository.GetByIdAsync(patientId, cancellationToken);
            _repositoryManager.PatientRepository.DeletePatient(patient);
            await _repositoryManager.UnitOfWork.SaveChangesAsync(cancellationToken);
        }
        public Task<PatientDto> GetByIdAsync(int patientId, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

    }
}
