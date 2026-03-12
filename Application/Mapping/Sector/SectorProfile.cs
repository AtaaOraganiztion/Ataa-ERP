using Application.Features.Sector.Commands.Add;
using Application.Features.Sector.Commands.Delete;
using Application.Features.Sector.Dtos;
using AutoMapper;

namespace Application.Mapping.Sector;

public class SectorProfile : Profile
{
    public SectorProfile()
    {
        CreateMap<AddSectorCommand, Domain.Models.Sector.Sector>()
            .ForMember(dest => dest.Id, opt => opt.MapFrom(src => Ulid.NewUlid()))
            .ForMember(dest => dest.ParentSectorId, opt => opt.MapFrom(src => src.ParentId))
            .ForMember(dest => dest.ManagerUserId, opt => opt.MapFrom(src => src.ManagerUserId))
            .ForMember(dest => dest.IsDeleted, opt => opt.MapFrom(src => false));

        CreateMap<UpdateSectorDto, Domain.Models.Sector.Sector>();
        CreateMap<Domain.Models.Sector.Sector, UpdateSectorDto>();

        CreateMap<Domain.Models.Sector.Sector, GetSectorDto>();

        CreateMap<GetSectorDto, Domain.Models.Sector.Sector>();

        CreateMap<DeleteSectorCommand, Domain.Models.Sector.Sector>()
            .ForMember(dest => dest.IsDeleted, opt => opt.MapFrom(src => true));
    }
}