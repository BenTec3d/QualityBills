using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace QualityBills.API.Employees
{
    [Authorize]
    [Route("api/v:{version:apiVersion}/employees")]
    [ApiController]
    [ApiVersion("1.0")]
    public class EmployeesController : ControllerBase
    {
        private readonly IEmployeeRepository _employeeRepository;
        private readonly IMapper _mapper;
        const int maxPageSize = 20;

        public EmployeesController(IEmployeeRepository employeeRepository, IMapper mapper)
        {
            _employeeRepository = employeeRepository ?? throw new ArgumentNullException(nameof(employeeRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        /// <summary>
        /// Gets all Employees
        /// </summary>
        /// <param name="searchQuery">An optional searchQuery to search by</param>
        /// <param name="pageNumber">The number of the page to get</param>
        /// <param name="pageSize">The size of the page to get (max. 20)</param>
        /// <returns>An ActionResult of IEnumerable of EmployeeDto</returns>
        /// <response code="200">Returns the requested Employees</response>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<IEnumerable<EmployeeDto>>> GetEmployeesAsync(string? searchQuery, int pageNumber = 1, int pageSize = 10)
        {
            if (pageSize > maxPageSize || pageSize < 0)
                pageSize = maxPageSize;

            var (employeeEntities, paginationMetadata) = await _employeeRepository.GetEmployeesAsync(searchQuery, pageNumber, pageSize);

            Response.Headers.Add("X-Pagination", JsonSerializer.Serialize(paginationMetadata));

            return Ok(_mapper.Map<IEnumerable<EmployeeDto>>(employeeEntities));
        }
    }
}
