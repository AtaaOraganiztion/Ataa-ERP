using Domain.Enums.CRM;
using Microsoft.AspNetCore.Http;

namespace Application.Features.CRM.GlobalActivity.Dtos;

public record UpdateGlobalActivityDto(
    ActivityType? Type,
    string? Subject,
    string? Description,
    DateTime? ActivityDate,
    ActivityStatus? Status,
    Ulid? CustomerId,
    Ulid? LeadId,
    Ulid? DealId,
    List<IFormFile>? Files,
    List<Ulid>? DeletedFileIds,
    ActivityResult ActivityResult 
);
