using Application.Features.CRM.Activity.Commands.Add;
using Application.Features.CRM.Activity.Dtos;
using AutoMapper;

public class ActivityProfile : Profile
{
    public ActivityProfile()
    {
        CreateMap<AddActivityCommand, Domain.Models.CRM.Activity.Activity>()
            .ForMember(x => x.Files, opt => opt.Ignore());

        CreateMap<UpdateActivityDto, Domain.Models.CRM.Activity.Activity>()
            .ForMember(dest => dest.Files, opt => opt.Ignore())
            .ForAllMembers(opt =>
                opt.Condition((src, dest, srcMember) =>
                    srcMember != null &&
                    !(srcMember is string str && string.IsNullOrWhiteSpace(str))));

        CreateMap<Domain.Models.CRM.Activity.Activity, GetActivityDto>()
            .ForMember(dest => dest.Files,
                opt => opt.MapFrom(src =>
                    src.Files ?? new List<Domain.Models.CRM.Activity.Activity.File>()));

        CreateMap<Domain.Models.CRM.Activity.Activity.File, ActivityFileDto>()
            .ForCtorParam("DownloadUrl", opt => opt.MapFrom(src =>
                $"/api/v1/activity/files/{src.Id}"));
    }
}