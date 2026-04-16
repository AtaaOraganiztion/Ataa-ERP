using Domain.Enums.CRM;

namespace Application.Features.CRM.Activity.Dtos;

public record UpdateActivityDto(
    ActivityType? Type,
    string? Subject,
    string? Description,
    DateTime? ActivityDate,
    ActivityStatus? Status,
    Ulid? CustomerId,
    Ulid? LeadId,
    Ulid? DealId,
    Ulid? AssignedToUserId,
    List<IFormFile>? Files,
    ActivityResult ActivityResult 
);