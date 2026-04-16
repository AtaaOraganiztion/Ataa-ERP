using Domain.Enums.CRM;

namespace Application.Features.CRM.Deal.Queries.GetAll;

public record DealFilter(
    string? Title,
    DealStatus? Status,
    Ulid? LeadId,
    Ulid? AssignedToUserId,
    decimal? MinValue,
    decimal? MaxValue,
    Ulid? CustomerId


);