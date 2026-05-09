using Application.Abstractions.Messaging;
using Domain.Models.CRM.GlobalActivity;

namespace Application.Features.CRM.GlobalActivity.Queries.GetFileById;

public record GetGlobalActivityFileByIdQuery(Ulid FileId)
    : IQuery<Domain.Models.CRM.GlobalActivity.GlobalActivity.File>;
