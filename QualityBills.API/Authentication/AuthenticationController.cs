using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using QualityBills.API.Employees;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace QualityBills.API.Authentication
{
    [Route("api/v:{version:apiVersion}/authentication")]
    [ApiController]
    [ApiVersion("1.0")]
    public class AuthenticationController : ControllerBase
    {
        private readonly IEmployeeRepository _employeeFinderRepository;
        private readonly IPasswordHashService _passwordHashService;
        private readonly IConfiguration _configuration;

        public AuthenticationController(IEmployeeRepository employeeFinderRepository, IPasswordHashService passwordHashService, IConfiguration configuration)
        {
            _employeeFinderRepository = employeeFinderRepository ?? throw new ArgumentNullException(nameof(employeeFinderRepository));
            _passwordHashService = passwordHashService ?? throw new ArgumentNullException(nameof(passwordHashService));
            _configuration = configuration ?? throw new ArgumentNullException(nameof(configuration));
        }

        /// <summary>
        /// Authenticates an employee and returns a JSON Web Token
        /// </summary>
        /// <param name="authenticationDto">The AuthenticationDto for the authentication</param>
        /// <returns>Action Result of string containing a JSON Web Token</returns>
        /// <response code="200">Returns a JSON Web Token</response>
        /// <response code="400">An AuthenticationDto is required</response>
        /// <response code="401">No employee found for provided AuthenticationDto</response>
        [HttpPost("authenticate")]
        public async Task<ActionResult<string>> Authenticate(AuthenticationDto authenticationDto)
        {
            var employees = await _employeeFinderRepository.GetEmployeesForAuthentificationAsync(authenticationDto.Username);

            if (employees.IsNullOrEmpty())
                return Unauthorized();

            Employee? employeeEntity = null;
            foreach (Employee employee in employees)
            {
                if (_passwordHashService.VerifyPasswordHash(authenticationDto.Password, employee.PasswordHash, employee.PasswordSalt))
                {
                    employeeEntity = employee;
                    break;
                }
            }

            if (employeeEntity is null)
                return Unauthorized();

            var securityKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(_configuration["Authentication:SecretForKey"]));
            var signingCredentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var claimsForToken = new List<Claim>()
            {
                new Claim("sub", employeeEntity.EmployeeId.ToString()),
                new Claim("preferred_username", employeeEntity.PreferredUsername),
                new Claim("family_name", employeeEntity.FamilyName),
                new Claim("given_name", employeeEntity.GivenName),
                new Claim("email", employeeEntity.Email),
                new Claim("birthdate", employeeEntity.Birthdate.ToString())
            };

            var jwtSecurityToken = new JwtSecurityToken(
                _configuration["Authentication:Issuer"],
                _configuration["Authentication:Audience"],
                claimsForToken,
                DateTime.UtcNow,
                DateTime.UtcNow.AddHours(1),
                signingCredentials
                );

            var tokenToReturn = new JwtSecurityTokenHandler().WriteToken(jwtSecurityToken);

            return Ok(tokenToReturn);
        }
    }
}
