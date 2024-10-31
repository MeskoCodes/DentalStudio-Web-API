using Contract;
using Contract.Account;
using Domain.Entities;
using Domain.Repositories;
using Domain.Repositories.Common;
using Mapster;
using Services.Abstractions;

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

        public Task<GeneralResponseDto> CreateTreatment(TreatmentCreateDto treatmentDto, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<GeneralResponseDto> DeleteTreatment(string treatmentId, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<TreatmentDto>> GetAllTreatments(CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<TreatmentDto> GetTreatmentById(string treatmentId, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<GeneralResponseDto> UpdateTreatment(string treatmentId, TreatmentUpdateDto treatmentDto, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        // Implement other methods (Delete, GetAll, GetById, Update) similarly
    }
}
