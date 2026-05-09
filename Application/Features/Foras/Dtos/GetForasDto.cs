namespace Application.Features.Foras.Dtos
{
    public record GetForasDto(
        Ulid Id,
        string? Title,
        DateTime? startdate,
        DateTime? enddate,
        string? Description,
        Ulid? CreatedByUserId,
        List<GetForasfileDto>? Files
    );

    public record GetForasfileDto(
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
