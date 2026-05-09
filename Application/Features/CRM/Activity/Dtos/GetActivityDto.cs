using Domain.Enums.CRM;

namespace Application.Features.CRM.Activity.Dtos;

public record GetActivityDto(
    Ulid Id,
    ActivityType Type,
    string Subject,
    string? Description,
    DateTime ActivityDate,
    ActivityStatus Status,
    Ulid? CustomerId,
    Ulid? LeadId,
    Ulid? DealId,
    Ulid? AssignedToUserId,
    Ulid? CreatedByUserId,
    ActivityResult ActivityResult,
    List<ActivityFileDto> Files   
);
public record ActivityFileDto(
    Ulid Id,
    string? FileName,
    string? ContentType,
    long? FileSizeInBytes,
    DateTime? UploadedAtUtc,
    Ulid? CreatedByUserId,
    string DownloadUrl
);