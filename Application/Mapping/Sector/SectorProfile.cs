using Application.Features.Sector.Commands.Add;
using AutoMapper;

namespace Application.Mapping.Sector;

public class SectorProfile : Profile
{
    public SectorProfile()
    {
        CreateMap<AddSectorCommand, Domain.Models.Sector>()
            .ForMember(dest => dest.Id, opt => opt.MapFrom(src => Ulid.NewUlid()))
            .ForMember(dest => dest.IsDeleted, opt => opt.MapFrom(src => false));

    }
}