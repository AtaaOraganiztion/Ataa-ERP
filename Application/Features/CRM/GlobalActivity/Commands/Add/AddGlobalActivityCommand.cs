using Application.Abstractions.Messaging;
using Domain.Enums.CRM;
using Microsoft.AspNetCore.Http;

namespace Application.Features.CRM.GlobalActivity.Commands.Add;

public record AddGlobalActivityCommand(
    ActivityType Type,
    string Subject,
    string? Description,
    DateTime ActivityDate,
    ActivityStatus Status,
    Ulid? CustomerId,
    Ulid? LeadId,
    Ulid? DealId,
    List<IFormFile>? Files,
    ActivityResult ActivityResult
) : ICommand<Ulid>;
