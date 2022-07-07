using Microsoft.AspNetCore.Mvc;

namespace QualityBills.API.Customers
{
    [Route("api/v:{version:apiVersion}/customers")]
    [ApiController]
    [ApiVersion("1.0")]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerRepository _customerRepository;
        private CancellationTokenSource cancellationTokenSource = new();

        public CustomerController(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository ?? throw new ArgumentNullException(nameof(customerRepository));
        }

        [HttpPost("sync")]
        public async Task<IActionResult> SyncCustomers()
        {
            await _customerRepository.SyncCustomersAsync(cancellationTokenSource.Token);
            return NoContent();
        }
    }
}
