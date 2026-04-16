using Domain.Enums.CRM;

namespace Application.Features.CRM.Customer.Dtos;

public record CustomerFilter(
    string? FullName,
    string? Email,
    string? Company,
    CustomerStatus? Status,
    Ulid? AssignedToUserId
);