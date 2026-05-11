using Application.Features.Adverisment.Commands.Add;
using Application.Features.Adverisment.Commands.Update;
using Application.Features.Adverisment.Dtos;
using AutoMapper;
using Domain.Models.Adverisment;

using Domain.Routing.BaseRouter;

namespace Application.Features.Adverisment.Mapping;

public class AdverismentMappingProfile : Profile
{
    public AdverismentMappingProfile()
    {
       
        CreateMap<AddAdverismentCommand, Domain.Models.Adverisment.Adverisment>()
            .ForMember(dest => dest.Title, opt => opt.MapFrom(src => src.Title))
            .ForMember(dest => dest.Description, opt => opt.MapFrom(src => src.Description))
            .ForMember(dest => dest.Url, opt => opt.MapFrom(src => src.Url))
            .ForMember(dest => dest.StartDate, opt => opt.MapFrom(src => src.StartDate))
            .ForMember(dest => dest.EndDate, opt => opt.MapFrom(src => src.EndDate))
            .ForMember(dest => dest.CreatedByUserId, opt => opt.MapFrom(src => src.CreatedByUserId))
            .ForMember(dest => dest.Files, opt => opt.Ignore());

        
        CreateMap<UpdateAdverismentDto, Domain.Models.Adverisment.Adverisment>()
            .ForMember(dest => dest.Title, opt => opt.MapFrom(src => src.Title))
            .ForMember(dest => dest.Description, opt => opt.MapFrom(src => src.Description))
            .ForMember(dest => dest.Url, opt => opt.MapFrom(src => src.Url))

            .ForMember(dest => dest.StartDate, opt => opt.MapFrom(src => src.startdate))
            .ForMember(dest => dest.EndDate, opt => opt.MapFrom(src => src.enddate))
            .ForMember(dest => dest.CreatedByUserId, opt => opt.MapFrom(src => src.CreatedByUserId))
            .ForMember(dest => dest.Files, opt => opt.Ignore());

        
        CreateMap<Domain.Models.Adverisment.Adverisment, GetAdverismentDto>()
            .ForCtorParam("Id", opt => opt.MapFrom(src => src.Id))
            .ForCtorParam("Title", opt => opt.MapFrom(src => src.Title))
            .ForCtorParam("Description", opt => opt.MapFrom(src => src.Description))
            .ForCtorParam("Url", opt => opt.MapFrom(src => src.Url))
            .ForCtorParam("startdate", opt => opt.MapFrom(src => src.StartDate))
            .ForCtorParam("enddate", opt => opt.MapFrom(src => src.EndDate))
            .ForCtorParam("CreatedByUserId", opt => opt.MapFrom(src => src.CreatedByUserId))
            .ForCtorParam("Files", opt => opt.MapFrom(src => src.Files));

       
        CreateMap<Domain.Models.Adverisment.Adverisment.AdverismentFile, GetAdverismentfileDto>()
            .ForCtorParam("Id", opt => opt.MapFrom(src => src.Id))
            .ForCtorParam("FileName", opt => opt.MapFrom(src => src.FileName))
            .ForCtorParam("ContentType", opt => opt.MapFrom(src => src.ContentType))
            .ForCtorParam("FileSizeInBytes", opt => opt.MapFrom(src => src.FileSizeInBytes))
            .ForCtorParam("UploadedAtUtc", opt => opt.MapFrom(src => src.UploadedAtUtc))
            .ForCtorParam("CreatedByUserId", opt => opt.MapFrom(src => src.CreatedByUserId))
            .ForCtorParam("PreviewUrl", opt => opt.MapFrom(src => "/" + Router.Adverisment.DownloadFile.Replace("{fileId}", src.Id.ToString())))
            .ForCtorParam("DownloadUrl", opt => opt.MapFrom(src => "/" + Router.Adverisment.DownloadFile.Replace("{fileId}", src.Id.ToString()) + "?download=true"));
    }
}