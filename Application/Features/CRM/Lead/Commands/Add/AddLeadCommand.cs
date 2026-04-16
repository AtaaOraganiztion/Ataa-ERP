using Application.Abstractions.Messaging;
using Domain.Enums.CRM;

namespace Application.Features.CRM.Lead.Commands.Add;

public record AddLeadCommand(
    string? Title,
    string? FullName,
    LeadStatus Status,
    LeadStage Stage,
    decimal? Value,
    DateTime? ExpectedCloseDate,
    string? Email,
    string? Phone,
    string? Company,
    string? Address,
    Ulid? CustomerId,
    Ulid? AssignedToUserId
) : ICommand<Ulid>;