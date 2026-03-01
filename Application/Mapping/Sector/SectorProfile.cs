using Application.Features.Sector.Commands.Add;
using AutoMapper;

namespace Application.Mapping.Sector;

public class SectorProfile : Profile
{
    public SectorProfile()
    {
        CreateMap<AddSectorCommand, Domain.Models.Sector>()
            .ForMember(dest => dest.Id, opt => opt.MapFrom(src => Ulid.NewUlid()))
            .ForMember(dest => dest.ParentSectorId, opt => opt.MapFrom(src => src.ParentId))
            .ForMember(dest => dest.ManagerUserId, opt => opt.MapFrom(src => src.ManagerId))
            .ForMember(dest => dest.IsDeleted, opt => opt.MapFrom(src => false));

    }
}