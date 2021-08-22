using AutoMapper;
using CadFunc.Application.DTOs;
using CadFunc.Domain.Entities;

namespace CadFunc.Application.Mappings
{
    public class DomainToDTOMappingProfile : Profile
    {
        public DomainToDTOMappingProfile()
        {
            CreateMap<Employee, EmployeeDTO>().ReverseMap();
        }
    }
}
