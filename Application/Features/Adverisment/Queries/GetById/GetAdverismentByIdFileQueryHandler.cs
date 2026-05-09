using Application.Abstractions.Messaging;
using Application.Abstractions.Repositories;
using Application.Features.Adverisment.Specifications;
using SharedKernel;

namespace Application.Features.Adverisment.Queries.GetFileById;

public class GetAdverismentFileByIdQueryHandler(
    IRepository<Domain.Models.Adverisment.Adverisment> repository)
    : IQueryHandler<GetAdverismentFileByIdQuery, Domain.Models.Adverisment.Adverisment.AdverismentFile>
{
    public async Task<Result<Domain.Models.Adverisment.Adverisment.AdverismentFile>> Handle(
        GetAdverismentFileByIdQuery request,
        CancellationToken cancellationToken)
    {
        var adverisment = await repository.FirstOrDefaultAsync(
            new AdverismentFileByIdSpec(request.FileId),
            cancellationToken);

        var file = adverisment?.Files.FirstOrDefault(f => f.Id == request.FileId);

        if (file is null)
            return Result.Failure<Domain.Models.Adverisment.Adverisment.AdverismentFile>(
                Error.NotFound("File not found"));

        return Result.Success(file);
    }
}