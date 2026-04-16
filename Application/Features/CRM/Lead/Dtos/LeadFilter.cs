using Domain.Enums.CRM;

namespace Application.Features.CRM.Lead.Queries.GetAll;

public record LeadFilter(
    string? Title,
    LeadStatus? Status,
    LeadStage? Stage,
    Ulid? CustomerId,
    Ulid? AssignedToUserId
);