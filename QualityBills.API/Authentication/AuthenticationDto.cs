namespace QualityBills.API.Authentication
{
    /// <summary>
    /// An employee DTO for authentication
    /// </summary>
    public class AuthenticationDto
    {
        /// <summary>
        /// The preferred Username of the employee
        /// </summary>
        public string Username { get; set; } = string.Empty;

        /// <summary>
        /// The password of the employee
        /// </summary>
        public string Password { get; set; } = string.Empty;
    }
}
