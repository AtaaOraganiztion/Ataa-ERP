using Application.Abstractions.Messaging;
using Domain.Enums.CRM;

namespace Application.Features.CRM.Deal.Commands.Add;

public record AddDealCommand : ICommand<Ulid>
{
    public Ulid? CustomerId { get; set; }
    public string Title { get; init; }
    public decimal Value { get; init; }
    public DealStatus Status { get; init; }
    public DateTime? ClosedDate { get; init; }
    public string? Notes { get; init; }
    public Ulid LeadId { get; init; }
    public Ulid? AssignedToUserId { get; init; }
}