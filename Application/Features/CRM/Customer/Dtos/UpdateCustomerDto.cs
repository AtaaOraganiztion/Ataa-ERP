using Domain.Enums.CRM;

namespace Application.Features.CRM.Customer.Dtos;

public record UpdateCustomerDto(
    string? FullName,
    string? Email,
    string? Phone,
    string? Company,
    string? Address,
    CustomerStatus? Status,
    string? Notes,
    Ulid? AssignedToUserId
);