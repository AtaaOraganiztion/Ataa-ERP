using Application.Features.Salary.Commands.Add;
using Application.Features.Salary.Commands.Delete;
using Application.Features.Salary.Dtos;
<<<<<<< HEAD
using Application.Features.Sector.Commands.Add;
using AutoMapper;

namespace Application.Mapping.Sector;
=======
using AutoMapper;

namespace Application.Mapping.Salary;
>>>>>>> 77a4b9b80bb4b9af37d4634bd1e93b7c284163be

public class SalaryProfile : Profile
{
    public SalaryProfile()
    {
        CreateMap<AddSalaryCommand, Domain.Models.Salary.Salary>()
            .ForMember(dest => dest.Id, opt => opt.MapFrom(src => Ulid.NewUlid()))
            .ForMember(dest => dest.IsDeleted, opt => opt.MapFrom(src => false));

        CreateMap<UpdateSalaryDto, Domain.Models.Salary.Salary>();
        CreateMap<Domain.Models.Salary.Salary, UpdateSalaryDto>();

<<<<<<< HEAD
        CreateMap<Domain.Models.Salary.Salary, GetSalaryDto>();
        CreateMap<GetSalaryDto, Domain.Models.Salary.Salary>();

        CreateMap<DeleteSalaryCommand, Domain.Models.Salary.Salary>()
            .ForMember(dest => dest.IsDeleted, opt => opt.MapFrom(src => true));

=======
        CreateMap<GetSalaryDto, Domain.Models.Salary.Salary>();
        CreateMap<Domain.Models.Salary.Salary,GetSalaryDto>();


        CreateMap<DeleteSalaryCommand, Domain.Models.Salary.Salary>()
            .ForMember(dest => dest.IsDeleted, opt => opt.MapFrom(src => true));
>>>>>>> 77a4b9b80bb4b9af37d4634bd1e93b7c284163be
    }
}