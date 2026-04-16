using Domain.Enums.CRM;

namespace Application.Features.CRM.Deal.Dtos;

public record UpdateDealDto(
    string? Title,
    decimal? Value,
    DealStatus? Status,
    DateTime? ClosedDate,
    string? Notes,
    Ulid? AssignedToUserId,
    Ulid? CustomerId
);  