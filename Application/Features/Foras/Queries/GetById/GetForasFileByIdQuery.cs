using Application.Abstractions.Messaging;

namespace Application.Features.Foras.Queries.GetFileById;

public record GetForasFileByIdQuery(Ulid FileId)
    : IQuery<Domain.Models.Foras.Foras.ForasFile>;
