namespace Services.Abstractions
{
    public interface IEmployeeService
    {
        Task<IEnumerable<EmployeeDto>> GetAllAsync(CancellationToken cancellationToken);
        Task<EmployeeDto> GetByIdAsync(int employeeId, CancellationToken cancellationToken);
        Task CreateAsync(EmployeeCreateDto employeeDto, CancellationToken cancellationToken);
        Task UpdateAsync(int employeeId, EmployeeUpdateDto employeeDto, CancellationToken cancellationToken);
        Task DeleteAsync(int employeeId, CancellationToken cancellationToken);
    }
}
