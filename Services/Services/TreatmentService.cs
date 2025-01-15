using Domain.Entities; // Uveri se da imaš potrebne using direktive
using Domain.Repositories;
using Domain.Repositories.Common;
using Services.Abstractions;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Services
{
    public class TreatmentService : ITreatmentService
    {
        private readonly IRepositoryManager _repositoryManager;

        public TreatmentService(IRepositoryManager repositoryManager)
        {
            _repositoryManager = repositoryManager;
        }

        public async Task<IEnumerable<TreatmentDto>> GetAllAsync(CancellationToken cancellationToken)
        {
          
            var treatments = await _repositoryManager.TreatmentRepository.GetAllAsync(cancellationToken);

            
            return treatments.Adapt<IEnumerable<TreatmentDto>>();
        }

        public async Task<TreatmentDto> GetByIdAsync(int treatmentId, CancellationToken cancellationToken)
        {
            
            var treatment = await _repositoryManager.TreatmentRepository.GetByIdAsync(treatmentId, cancellationToken);

          
            if (treatment == null)
            {
               
                return null; 
            }

 
            return treatment.Adapt<TreatmentDto>();
        }

        public async Task CreateAsync(TreatmentCreateDto treatmentDto, CancellationToken cancellationToken)
        {
       
        }

        public async Task UpdateAsync(int treatmentId, TreatmentUpdateDto treatmentDto, CancellationToken cancellationToken)
        {
            
        }

        public async Task DeleteAsync(int treatmentId, CancellationToken cancellationToken)
        {
            
        }
    }
}
