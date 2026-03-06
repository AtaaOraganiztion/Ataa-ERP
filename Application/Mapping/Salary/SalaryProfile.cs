using Application.Features.Salary.Commands.Add;
using Application.Features.Salary.Commands.Delete;
using Application.Features.Salary.Dtos;
using AutoMapper;

namespace Application.Mapping.Salary;

public class SalaryProfile : Profile
{
    public SalaryProfile()
    {
        CreateMap<AddSalaryCommand, Domain.Models.Salary.Salary>()
            .ForMember(dest => dest.Id, opt => opt.MapFrom(src => Ulid.NewUlid()))
            .ForMember(dest => dest.IsDeleted, opt => opt.MapFrom(src => false));

        CreateMap<UpdateSalaryDto, Domain.Models.Salary.Salary>();
        CreateMap<Domain.Models.Salary.Salary, UpdateSalaryDto>();

        CreateMap<GetSalaryDto, Domain.Models.Salary.Salary>();
        CreateMap<Domain.Models.Salary.Salary,GetSalaryDto>();


        CreateMap<DeleteSalaryCommand, Domain.Models.Salary.Salary>()
            .ForMember(dest => dest.IsDeleted, opt => opt.MapFrom(src => true));
    }
}