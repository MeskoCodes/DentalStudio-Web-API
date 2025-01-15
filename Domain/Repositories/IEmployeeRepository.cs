namespace Domain.Repositories
{
    public interface IEmployeeRepository
    {
        Task<Employee> GetByIdAsync(int EmployeeId, CancellationToken cancellationToken = default);
        Task<IEnumerable<Employee>> GetAllAsync(CancellationToken cancellationToken = default);
        Task CreateEmployee(Employee Employee); // Takođe bi mogla da bude asinkrona
        Task UpdateEmployee(Employee Employee); // Takođe bi mogla da bude asinkrona
        Task DeleteEmployee(Employee Employee, CancellationToken cancellationToken); // Ažurirano
    }
}
