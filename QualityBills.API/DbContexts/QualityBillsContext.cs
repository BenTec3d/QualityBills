using Microsoft.EntityFrameworkCore;
using QualityBills.API.Authentication;
using QualityBills.API.Employees;
using QualityBills.API.Customers;

namespace QualityBills.API.DbContexts
{
    public class QualityBillsContext : DbContext
    {
        private readonly IPasswordHashService _passwordHashService;

        public DbSet<Employee> Employees { get; set; } = null!;
        public DbSet<Customer> Customers { get; set; } = null!;

        public QualityBillsContext(IPasswordHashService passwordHashService, DbContextOptions<QualityBillsContext> options) : base(options)
        {
            _passwordHashService = passwordHashService ?? throw new ArgumentNullException(nameof(passwordHashService));
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            PasswordHashService passwordHashService = new();
            passwordHashService.CreatePasswordHash("password", out byte[] passwordHash, out byte[] passwordSalt);

            modelBuilder.Entity<Employee>().HasData(
                new Employee(passwordHash, passwordSalt, "username", "familyName", "givenName", "test@email.de", new DateOnly(2022, 06, 07))
                {
                    EmployeeId = 1
                }
            );

            base.OnModelCreating(modelBuilder);
        }
    }
}
