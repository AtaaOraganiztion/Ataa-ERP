namespace Application.Features.Adverisment.Dtos
{
    public record UpdateAdverismentDto(

        string? Title,
        DateTime? startdate,
        DateTime? enddate,
        string? Description,
        Ulid? FileId,
        Ulid? CreatedByUserId,
        string? Url,
        List<IFormFile>?Files,
        List<Ulid>? DeletedFileIds
        );
}
