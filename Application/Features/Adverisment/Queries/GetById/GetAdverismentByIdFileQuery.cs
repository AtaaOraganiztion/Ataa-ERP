using Application.Abstractions.Messaging;

namespace Application.Features.Adverisment.Queries.GetFileById;

public record GetAdverismentFileByIdQuery(Ulid FileId)
    : IQuery<Domain.Models.Adverisment.Adverisment.AdverismentFile>;