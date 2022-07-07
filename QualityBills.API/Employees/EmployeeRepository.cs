using Microsoft.EntityFrameworkCore;
using QualityBills.API.DbContexts;
using QualityBills.API.Metadata;
using System;

namespace QualityBills.API.Employees
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly QualityBillsContext _context;

        public EmployeeRepository(QualityBillsContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<(IEnumerable<Employee>, PaginationMetadata)> GetEmployeesAsync(string? searchQuery, int pageNumber, int pageSize)
        {
            var collection = _context.Employees as IQueryable<Employee>;

            if (!string.IsNullOrWhiteSpace(searchQuery))
            {
                searchQuery = searchQuery.Trim().ToLower();
                collection = collection.Where(x => x.PreferredUsername.ToLower().Contains(searchQuery)
                || x.FamilyName.ToLower().Contains(searchQuery)
                || x.GivenName.ToLower().Contains(searchQuery)
                || x.Email.ToLower().Contains(searchQuery));
            }

            var totalItemCount = await collection.CountAsync();
            var paginationMetadata = new PaginationMetadata(totalItemCount, pageSize, pageNumber);

            var collectionToReturn = await collection.Skip(pageSize * (pageNumber - 1)).Take(pageSize).ToListAsync();

            return (collectionToReturn, paginationMetadata);
        }

        public async Task<IEnumerable<Employee>> GetEmployeesForAuthentificationAsync(string preferredUsername)
        {
            return await _context.Employees.Where(x => x.PreferredUsername == preferredUsername).ToListAsync();
        }
    }
}
