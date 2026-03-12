using Application.Features.Employee.Commands.Add;
using Application.Features.Employee.Commands.Delete;
using Application.Features.Employee.Dtos;
using AutoMapper;

namespace Application.Mapping.Employee;

public class EmployeeProfile : Profile
{
    public EmployeeProfile()
    {
        CreateMap<AddEmployeeCommand, Domain.Models.Employee.Employee>()
            .ForMember(dest => dest.Id, opt => opt.MapFrom(src => Ulid.NewUlid()))
            .ForMember(dest => dest.IsDeleted, opt => opt.MapFrom(src => false));

        CreateMap<UpdateEmployeeDto, Domain.Models.Employee.Employee>();
        CreateMap<Domain.Models.Employee.Employee, UpdateEmployeeDto>();

        CreateMap<Domain.Models.Employee.Employee, GetEmployeeDto>()
            .ForMember(dest => dest.SectorName,
                opt => opt.MapFrom(src => src.Sector != null ? src.Sector.Name : null));

        CreateMap<GetEmployeeDto, Domain.Models.Employee.Employee>();

        CreateMap<DeleteEmployeeCommand, Domain.Models.Employee.Employee>()
            .ForMember(dest => dest.IsDeleted, opt => opt.MapFrom(src => true));
    }
}