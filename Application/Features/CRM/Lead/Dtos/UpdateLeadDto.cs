using Domain.Enums.CRM;

namespace Application.Features.CRM.Lead.Dtos;

public record UpdateLeadDto(
    string? Title,
    decimal? Value,
    LeadStatus? Status,
    LeadStage? Stage,
    DateTime? ExpectedCloseDate,
    string? Notes,

    string? FullName,
    string? Email,
    string? Phone,
    string? Company,
    string? Address,

    Ulid? CustomerId,
    Ulid? AssignedToUserId
);