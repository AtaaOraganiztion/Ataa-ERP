using Application.Abstractions.Messaging;
using Domain.Models.CRM.Activity;

namespace Application.Features.CRM.Activity.Queries.GetFileById;

public record GetActivityFileByIdQuery(Ulid FileId)
    : IQuery<Domain.Models.CRM.Activity.Activity.File>;