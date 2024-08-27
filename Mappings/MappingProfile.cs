using AutoMapper;
using EmployeeApi.DTOs;
using EmployeeApi.Models;

namespace EmployeeApi.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Employee, EmployeeDto>().ReverseMap();
        }
    }
}
