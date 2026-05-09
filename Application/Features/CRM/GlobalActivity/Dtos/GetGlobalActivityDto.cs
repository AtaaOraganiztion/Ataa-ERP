using Domain.Enums.CRM;

namespace Application.Features.CRM.GlobalActivity.Dtos;

public record GetGlobalActivityDto(
    Ulid Id,
    ActivityType Type,
    string Subject,
    string? Description,
    DateTime ActivityDate,
    ActivityStatus Status,
    Ulid? CustomerId,
    Ulid? LeadId,
    Ulid? DealId,
    Ulid? CreatedByUserId,
    ActivityResult ActivityResult,
    List<GlobalActivityFileDto> Files   
);

public record GlobalActivityFileDto(
    Ulid Id,
    string? FileName,
    string? ContentType,
    long? FileSizeInBytes,
    DateTime? UploadedAtUtc,
    Ulid? CreatedByUserId,
    string DownloadUrl
);
