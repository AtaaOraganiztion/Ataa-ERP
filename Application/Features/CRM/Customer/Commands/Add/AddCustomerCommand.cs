using Application.Abstractions.Messaging;
using Domain.Enums.CRM;

namespace Application.Features.CRM.Customer.Commands.Add;

public record AddCustomerCommand : ICommand<Ulid>
{
    public string? FullName { get; init; }
    public string? Email { get; init; }
    public string? Phone { get; init; }
    public string? Company { get; init; }
    public string? Address { get; init; }
    public CustomerStatus Status { get; init; }
    public string? Notes { get; init; }
    public Ulid? AssignedToUserId { get; init; }
}