namespace Application.Features.Adverisment.Dtos
{
    public record GetAdverismentDto(
        Ulid Id,
        string? Title,
        DateTime? startdate,
        DateTime? enddate,
        string? Description,
        Ulid? CreatedByUserId,
         List<GetAdverismentfileDto>? Files,
        string? Url

        );
    
    public record GetAdverismentfileDto(
    Ulid Id,
    string? FileName,
    string? ContentType,
    long? FileSizeInBytes,
    DateTime? UploadedAtUtc,
    Ulid? CreatedByUserId,
    string PreviewUrl,
    string DownloadUrl
);
}
