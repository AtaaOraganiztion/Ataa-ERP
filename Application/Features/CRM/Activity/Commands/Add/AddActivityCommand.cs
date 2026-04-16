// AddActivityCommand.cs
using Application.Abstractions.Messaging;
using Domain.Enums.CRM;
using Microsoft.AspNetCore.Http;

namespace Application.Features.CRM.Activity.Commands.Add;

public record AddActivityCommand(
    ActivityType Type,
    string Subject,
    string? Description,
    DateTime ActivityDate,
    ActivityStatus Status,
    Ulid? CustomerId,
    Ulid? LeadId,
    Ulid? DealId,
    Ulid? AssignedToUserId,
    List<IFormFile>? Files,
    ActivityResult ActivityResult
) : ICommand<Ulid>;