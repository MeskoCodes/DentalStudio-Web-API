namespace Services.Abstractions
{
    public interface ITreatmentService
    {
        Task<IEnumerable<TreatmentDto>> GetAllAsync(CancellationToken cancellationToken);
        Task<TreatmentDto> GetByIdAsync(int treatmentId, CancellationToken cancellationToken);
        Task CreateAsync(TreatmentCreateDto treatmentDto, CancellationToken cancellationToken);
        Task UpdateAsync(int treatmentId, TreatmentUpdateDto treatmentDto, CancellationToken cancellationToken);
        Task DeleteAsync(int treatmentId, CancellationToken cancellationToken);
    }
}
