using Application.Features.Foras.Commands.Add;
using Application.Features.Foras.Commands.Update;
using Application.Features.Foras.Dtos;
using AutoMapper;
using Domain.Models.Foras;

using Domain.Routing.BaseRouter;

namespace Application.Features.Foras.Mapping;

public class ForasMappingProfile : Profile
{
    public ForasMappingProfile()
    {
        CreateMap<AddForasCommand, Domain.Models.Foras.Foras>()
            .ForMember(dest => dest.Title, opt => opt.MapFrom(src => src.Title))
            .ForMember(dest => dest.Description, opt => opt.MapFrom(src => src.Description))
            .ForMember(dest => dest.Url, opt => opt.MapFrom(src => src.Url))

            .ForMember(dest => dest.StartDate, opt => opt.MapFrom(src => src.StartDate))
            .ForMember(dest => dest.EndDate, opt => opt.MapFrom(src => src.EndDate))
            .ForMember(dest => dest.CreatedByUserId, opt => opt.MapFrom(src => src.CreatedByUserId))
            .ForMember(dest => dest.Files, opt => opt.Ignore());

        CreateMap<UpdateForasDto, Domain.Models.Foras.Foras>()
            .ForMember(dest => dest.Title, opt => opt.MapFrom(src => src.Title))
            .ForMember(dest => dest.Description, opt => opt.MapFrom(src => src.Description)).ForMember(dest => dest.Url, opt => opt.MapFrom(src => src.Url))

            .ForMember(dest => dest.StartDate, opt => opt.MapFrom(src => src.startdate))
            .ForMember(dest => dest.EndDate, opt => opt.MapFrom(src => src.enddate))
            .ForMember(dest => dest.CreatedByUserId, opt => opt.MapFrom(src => src.CreatedByUserId))
            .ForMember(dest => dest.Files, opt => opt.Ignore());

        CreateMap<Domain.Models.Foras.Foras, GetForasDto>()
            .ForCtorParam("Id", opt => opt.MapFrom(src => src.Id))
            .ForCtorParam("Title", opt => opt.MapFrom(src => src.Title))
            .ForCtorParam("Description", opt => opt.MapFrom(src => src.Description)).ForCtorParam("Url", opt => opt.MapFrom(src => src.Url))

            .ForCtorParam("startdate", opt => opt.MapFrom(src => src.StartDate))
            .ForCtorParam("enddate", opt => opt.MapFrom(src => src.EndDate))
            .ForCtorParam("CreatedByUserId", opt => opt.MapFrom(src => src.CreatedByUserId))
            .ForCtorParam("Files", opt => opt.MapFrom(src => src.Files));

        CreateMap<Domain.Models.Foras.Foras.ForasFile, GetForasfileDto>()
            .ForCtorParam("Id", opt => opt.MapFrom(src => src.Id))
            .ForCtorParam("FileName", opt => opt.MapFrom(src => src.FileName))
            .ForCtorParam("ContentType", opt => opt.MapFrom(src => src.ContentType))
            .ForCtorParam("FileSizeInBytes", opt => opt.MapFrom(src => src.FileSizeInBytes))
            .ForCtorParam("UploadedAtUtc", opt => opt.MapFrom(src => src.UploadedAtUtc))
            .ForCtorParam("CreatedByUserId", opt => opt.MapFrom(src => src.CreatedByUserId))
            .ForCtorParam("PreviewUrl", opt => opt.MapFrom(src => "/" + Router.Foras.DownloadFile.Replace("{fileId}", src.Id.ToString())))
            .ForCtorParam("DownloadUrl", opt => opt.MapFrom(src => "/" + Router.Foras.DownloadFile.Replace("{fileId}", src.Id.ToString()) + "?download=true"));
    }
}