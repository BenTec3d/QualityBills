using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace QualityBills.API.Employees
{
    public class EmployeeDto
    {
        public int Id { get; set; }
        public string PreferredUsername { get; set; } = string.Empty;
        public string FamilyName { get; set; } = string.Empty;
        public string GivenName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public DateOnly Birthdate { get; set; }
    }
}
