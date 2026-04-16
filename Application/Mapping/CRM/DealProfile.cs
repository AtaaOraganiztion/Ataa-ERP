using Application.Features.CRM.Deal.Commands.Add;
using Application.Features.CRM.Deal.Dtos;
using AutoMapper;

namespace Application.Mapping.CRM;

public class DealProfile : Profile
{
    public DealProfile()
    {
        CreateMap<AddDealCommand, Domain.Models.CRM.Deal.Deal>()
            .ForMember(dest => dest.Id, opt => opt.MapFrom(src => Ulid.NewUlid()));

        CreateMap<UpdateDealDto, Domain.Models.CRM.Deal.Deal>()
            .ForAllMembers(opt => opt.Condition((src, dest, srcMember) => srcMember != null));

        CreateMap<Domain.Models.CRM.Deal.Deal, GetDealDto>()
            .ForCtorParam("id", opt => opt.MapFrom(src => src.Id))
            .ForCtorParam("title", opt => opt.MapFrom(src => src.Title))
            .ForCtorParam("value", opt => opt.MapFrom(src => src.Value))
            .ForCtorParam("status", opt => opt.MapFrom(src => src.Status))
            .ForCtorParam("closedDate", opt => opt.MapFrom(src => src.ClosedDate))
            .ForCtorParam("notes", opt => opt.MapFrom(src => src.Notes))
            .ForCtorParam("leadId", opt => opt.MapFrom(src => src.LeadId))
            .ForCtorParam("assignedToUserId", opt => opt.MapFrom(src => src.AssignedToUserId));
    }
}