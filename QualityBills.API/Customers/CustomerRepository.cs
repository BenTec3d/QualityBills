using AutoMapper;
using QualityBills.API.DbContexts;
using QualityBills.API.HttpClients;

namespace QualityBills.API.Customers
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly QualityBillsContext _context;
        private readonly FastBillClient _fastBillClient;
        private readonly IMapper _mapper;

        public CustomerRepository(QualityBillsContext context, FastBillClient fastBillClient, IMapper mapper)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
            _fastBillClient = fastBillClient ?? throw new ArgumentNullException(nameof(fastBillClient));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public async Task SyncCustomersAsync(CancellationToken cancellationToken)
        {
            var fastBillCustomers = await _fastBillClient.GetCustomersAsync(cancellationToken);
            var CustomerEntities = _mapper.Map<IEnumerable<Customer>>(fastBillCustomers);

            foreach(var customer in CustomerEntities)
            {
                if (_context.Customers.Any(x => x.CustomerId == customer.CustomerId))
                    _context.Customers.Update(customer);
                else
                    _context.Customers.Add(customer);
            }
            foreach (var customer in _context.Customers)
            {
                if (!fastBillCustomers.Any(x => x.CustomerId == customer.CustomerId))
                    _context.Customers.Remove(customer);
            }
            await _context.SaveChangesAsync();
        }
    }
}
