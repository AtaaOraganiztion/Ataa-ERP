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
            .ForCtorParam("Id", opt => opt.MapFrom(src => src.Id))
            .ForCtorParam("Type", opt => opt.MapFrom(src => src.Type))
            .ForCtorParam("Subject", opt => opt.MapFrom(src => src.Subject))
            .ForCtorParam("Description", opt => opt.MapFrom(src => src.Description))
            .ForCtorParam("ActivityDate", opt => opt.MapFrom(src => src.ActivityDate))
            .ForCtorParam("Status", opt => opt.MapFrom(src => src.Status))
            .ForCtorParam("CustomerId", opt => opt.MapFrom(src => src.CustomerId))
            .ForCtorParam("LeadId", opt => opt.MapFrom(src => src.LeadId))
            .ForCtorParam("DealId", opt => opt.MapFrom(src => src.DealId))
            .ForCtorParam("AssignedToUserId", opt => opt.MapFrom(src => src.AssignedToUserId))
            .ForCtorParam("CreatedByUserId", opt => opt.MapFrom(src => src.CreatedByUserId))
            .ForCtorParam("ActivityResult", opt => opt.MapFrom(src => src.ActivityResult))
            .ForCtorParam("Files", opt => opt.MapFrom(src => src.Files ?? new List<Domain.Models.CRM.Activity.Activity.File>()));

        CreateMap<Domain.Models.CRM.Activity.Activity.File, ActivityFileDto>()
            .ForCtorParam("Id", opt => opt.MapFrom(src => src.Id))
            .ForCtorParam("FileName", opt => opt.MapFrom(src => src.FileName))
            .ForCtorParam("ContentType", opt => opt.MapFrom(src => src.ContentType))
            .ForCtorParam("FileSizeInBytes", opt => opt.MapFrom(src => src.FileSizeInBytes))
            .ForCtorParam("UploadedAtUtc", opt => opt.MapFrom(src => src.UploadedAtUtc))
            .ForCtorParam("CreatedByUserId", opt => opt.MapFrom(src => src.CreatedByUserId))
            .ForCtorParam("DownloadUrl", opt => opt.MapFrom(src =>
                $"/api/v1/activity/files/{src.Id}"));
    }
}