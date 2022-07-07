using QualityBills.API.Metadata;

namespace QualityBills.API.Employees
{
    public interface IEmployeeRepository
    {
        Task<(IEnumerable<Employee>, PaginationMetadata)> GetEmployeesAsync(string? searchQuery, int pageNumber, int pageSize);
        Task<IEnumerable<Employee>> GetEmployeesForAuthentificationAsync(string preferredUsername);
    }
}
