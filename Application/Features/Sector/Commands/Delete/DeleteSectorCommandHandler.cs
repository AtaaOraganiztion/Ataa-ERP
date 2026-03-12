using Application.Abstractions.Messaging;
using Application.Abstractions.Repositories;
using Application.Features.Sector.Specifications;
using Domain.Models;
using SharedKernel;

namespace Application.Features.Sector.Commands.Delete;

public class DeleteSectorCommandHandler(IRepository<Domain.Models.Sector.Sector> repository) : ICommandHandler<DeleteSectorCommand,Ulid>
{
    public async Task<Result<Ulid>> Handle(DeleteSectorCommand request, CancellationToken cancellationToken)
    {
        var sector = await repository.FirstOrDefaultAsync(new SectorByIdSpec(request.Id),cancellationToken);
        if (sector is null)
        {
            return Result.Failure<Ulid>(Error.NotFound(SectorMessageKey.SectorNotFound));
        }

        await repository.DeleteAsync(sector, cancellationToken);
        return Result.Success(sector.Id);
    }
}