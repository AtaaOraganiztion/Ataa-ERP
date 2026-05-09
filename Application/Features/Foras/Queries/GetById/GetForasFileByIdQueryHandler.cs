using Application.Abstractions.Messaging;
using Application.Abstractions.Repositories;
using Application.Features.Foras.Specifications;
using SharedKernel;

namespace Application.Features.Foras.Queries.GetFileById;

public class GetForasFileByIdQueryHandler(
    IRepository<Domain.Models.Foras.Foras> repository)
    : IQueryHandler<GetForasFileByIdQuery, Domain.Models.Foras.Foras.ForasFile>
{
    public async Task<Result<Domain.Models.Foras.Foras.ForasFile>> Handle(
        GetForasFileByIdQuery request,
        CancellationToken cancellationToken)
    {
        var foras = await repository.FirstOrDefaultAsync(
            new ForasFileByIdSpec(request.FileId),
            cancellationToken);

        var file = foras?.Files.FirstOrDefault(f => f.Id == request.FileId);

        if (file is null)
            return Result.Failure<Domain.Models.Foras.Foras.ForasFile>(
                Error.NotFound("File not found"));

        return Result.Success(file);
    }
}
