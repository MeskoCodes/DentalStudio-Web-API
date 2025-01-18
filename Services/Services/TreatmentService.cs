using Domain.Repositories.Common;

namespace Services
{
    public class TreatmentService(IRepositoryManager repositoryManager) : ITreatmentService
    {
        public async Task<GeneralResponseDto> Create(TreatmentCreateDto treatmentDto, CancellationToken cancellationToken = default)
        {
            try
            {
                var treatment = treatmentDto.Adapt<Treatment>();
                repositoryManager.TreatmentRepository.CreateTreatment(treatment);
                var rowsAffected = await repositoryManager.UnitOfWork.SaveChangesAsync(cancellationToken);
                if (rowsAffected != 1)
                {
                    return new GeneralResponseDto
                    {
                        IsSuccess = false,
                        Message = "Error!"
                    };
                }

                return new GeneralResponseDto { Data = treatment.TreatmentId, Message = "Success!" };
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

        public async Task Delete(int treatmentId, CancellationToken cancellationToken = default)
        {
            var treatment = await repositoryManager.TreatmentRepository.GetById(treatmentId, cancellationToken);
            repositoryManager.TreatmentRepository.DeleteTreatment(treatment, cancellationToken);
            await repositoryManager.UnitOfWork.SaveChangesAsync(cancellationToken);
        }

        public async Task<IEnumerable<TreatmentDto>> GetAll(CancellationToken cancellationToken = default)
        {
            var treatments = await repositoryManager.TreatmentRepository.GetAll(cancellationToken);
            return treatments.Adapt<IEnumerable<TreatmentDto>>();
        }

        public async Task<TreatmentDto> GetById(int treatmentId, CancellationToken cancellationToken = default)
        {
            var treatment = await repositoryManager.TreatmentRepository.GetById(treatmentId, cancellationToken);
            return treatment.Adapt<TreatmentDto>();
        }

        public async Task<GeneralResponseDto> Update(int treatmentId, TreatmentUpdateDto treatmentDto, CancellationToken cancellationToken = default)
        {
            try
            {
                var existingTreatment = await repositoryManager.TreatmentRepository.GetById(treatmentId, cancellationToken);
                if (existingTreatment == null)
                    return new GeneralResponseDto { IsSuccess = false, Message = "Treatment not found." };

                treatmentDto.Adapt(existingTreatment);

                repositoryManager.TreatmentRepository.UpdateTreatment(existingTreatment);
                var res = await repositoryManager.UnitOfWork.SaveChangesAsync(cancellationToken);
                if (res != 1)
                    return new GeneralResponseDto { IsSuccess = false };

                return new GeneralResponseDto { Data = existingTreatment.TreatmentId, Message = "Success!" };
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