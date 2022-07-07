using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace QualityBills.API.Employees
{
    public class Employee
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int EmployeeId { get; set; }
        [Required]
        public byte[] PasswordHash { get; set; }
        [Required]
        public byte[] PasswordSalt { get; set; }
        [Required]
        [MaxLength(50)]
        public string PreferredUsername { get; set; }
        [Required]
        [MaxLength(50)]
        public string FamilyName { get; set; }
        [Required]
        [MaxLength(50)]
        public string GivenName { get; set; }
        [Required]
        [MaxLength(50)]
        public string Email { get; set; }
        [Required]
        [MaxLength(50)]
        public DateOnly Birthdate { get; set; }

        public Employee(byte[] passwordHash, byte[] passwordSalt, string preferredUsername, string familyName, string givenName, string email, DateOnly birthdate)
        {
            PasswordHash = passwordHash;
            PasswordSalt = passwordSalt;
            PreferredUsername = preferredUsername;
            FamilyName = familyName;
            GivenName = givenName;
            Email = email;
            Birthdate = birthdate;
        }
    }
}
