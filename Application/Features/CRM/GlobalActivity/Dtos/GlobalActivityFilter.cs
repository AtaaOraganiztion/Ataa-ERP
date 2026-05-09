using Domain.Enums.CRM;

namespace Application.Features.CRM.GlobalActivity.Dtos;

public record GlobalActivityFilter(
    ActivityType? Type,
    ActivityStatus? Status,
    Ulid? CustomerId,
    Ulid? LeadId,
    Ulid? DealId,
    DateTime? FromDate,
    DateTime? ToDate,
    ActivityResult? ActivityResult
);
