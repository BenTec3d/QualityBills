using AutoMapper;

namespace QualityBills.API.Customers
{
    public class CustomerAutoMapperProfile : Profile
    {
        public CustomerAutoMapperProfile()
        {
            CreateMap<FastBillCustomerDto, Customer>();
        }
    }
}
