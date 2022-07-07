using AutoMapper;

namespace QualityBills.API.Employees
{
    public class EmployeeAutoMapperProfile : Profile
    {
        public EmployeeAutoMapperProfile()
        {
            CreateMap<Employee, EmployeeDto>();
        }
    }
}
