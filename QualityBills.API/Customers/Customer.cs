using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace QualityBills.API.Customers
{
    public class Customer
    {
        [Key]
        public int CustomerId { get; set; }
        public string CustomerNumber { get; set; }
        public string CustomerType { get; set; }
        public DateTime Created { get; set; }
        public string BankName { get; set; }
        public string BankIban { get; set; }
        public string BankBic { get; set; }
        public string BankAccountOwner { get; set; }
        public string Organization { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public string Address2 { get; set; }
        public string ZipCode { get; set; }
        public string City { get; set; }
        public string CountryCode { get; set; }
        public string Phone { get; set; }
        public string Mobile { get; set; }
        public string Email { get; set; }
        public string VatId { get; set; }

        public Customer(int customerId)
        {
            CustomerId = customerId;
        }
    }
}
