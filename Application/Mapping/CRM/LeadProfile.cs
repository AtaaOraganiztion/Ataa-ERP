using Application.Features.CRM.Lead.Commands.Add;
using Application.Features.CRM.Lead.Dtos;
using AutoMapper;

namespace Application.Mapping.CRM;

public class LeadProfile : Profile
{
    public LeadProfile()
    {
        CreateMap<AddLeadCommand, Domain.Models.CRM.Lead.Lead>()
            .ForMember(dest => dest.Id, opt => opt.MapFrom(src => Ulid.NewUlid()));

        CreateMap<UpdateLeadDto, Domain.Models.CRM.Lead.Lead>()
            .ForAllMembers(opt => opt.Condition((src, dest, srcMember) => srcMember != null));

        CreateMap<Domain.Models.CRM.Lead.Lead, GetLeadDto>()
            .ForCtorParam("id", opt => opt.MapFrom(src => src.Id))
            .ForCtorParam("title", opt => opt.MapFrom(src => src.Title))
            .ForCtorParam("value", opt => opt.MapFrom(src => src.Value))
            .ForCtorParam("status", opt => opt.MapFrom(src => src.Status))
            .ForCtorParam("stage", opt => opt.MapFrom(src => src.Stage))
            .ForCtorParam("expectedCloseDate", opt => opt.MapFrom(src => src.ExpectedCloseDate))
            .ForCtorParam("notes", opt => opt.MapFrom(src => src.Notes))
            .ForCtorParam("customerId", opt => opt.MapFrom(src => src.CustomerId))
            .ForCtorParam("assignedToUserId", opt => opt.MapFrom(src => src.AssignedToUserId));
            
    }
}