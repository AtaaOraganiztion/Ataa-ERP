using Application.Features.CRM.Activity.Dtos;
using Domain.Enums.CRM;

namespace Application.Features.CRM.Activity.Queries.GetAll;

public record ActivityFilter(
    ActivityType? Type,
    ActivityStatus? Status,
    Ulid? CustomerId,
    Ulid? LeadId,
    Ulid? DealId,
    Ulid? AssignedToUserId,
    DateTime? FromDate,
    DateTime? ToDate,
    Ulid? FileId,
    ActivityResult? ActivityResult
);