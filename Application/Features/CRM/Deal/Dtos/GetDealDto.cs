using Domain.Enums.CRM;

namespace Application.Features.CRM.Deal.Dtos;

public record GetDealDto(
    Ulid Id,
    string Title,
    decimal Value,
    DealStatus Status,
    DateTime? ClosedDate,
    string? Notes,
    Ulid LeadId,
    Ulid? AssignedToUserId,
    Ulid? CustomerId
);