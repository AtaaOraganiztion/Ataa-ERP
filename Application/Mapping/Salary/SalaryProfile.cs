using Application.Features.Salary.Commands.Add;
using Application.Features.Salary.Commands.Delete;
using Application.Features.Salary.Dtos;
using Application.Features.Sector.Commands.Add;
using AutoMapper;

namespace Application.Mapping.Sector;

public class SalaryProfile : Profile
{
    public SalaryProfile()
    {
        CreateMap<AddSalaryCommand, Domain.Models.Salary.Salary>()
            .ForMember(dest => dest.Id, opt => opt.MapFrom(src => Ulid.NewUlid()))
            .ForMember(dest => dest.IsDeleted, opt => opt.MapFrom(src => false));

        CreateMap<UpdateSalaryDto, Domain.Models.Salary.Salary>();
        CreateMap<Domain.Models.Salary.Salary, UpdateSalaryDto>();

        CreateMap<Domain.Models.Salary.Salary, GetSalaryDto>();
        CreateMap<GetSalaryDto, Domain.Models.Salary.Salary>();

        CreateMap<DeleteSalaryCommand, Domain.Models.Salary.Salary>()
            .ForMember(dest => dest.IsDeleted, opt => opt.MapFrom(src => true));

    }
}