namespace QualityBills.API.Customers
{
    public interface ICustomerRepository
    {
        Task SyncCustomersAsync(CancellationToken cancellationToken);
    }
}
