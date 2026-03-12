using Application.Abstractions.Messaging;
using Application.Abstractions.Repositories;
using Application.Features.Sector.Specifications;
using AutoMapper;
using Domain.Models;
using Domain.Models.Sector;
using SharedKernel;

namespace Application.Features.Sector.Commands.Update;

public class UpdateSectorCommandHandler(IMapper mapper, IRepository<Domain.Models.Sector.Sector> repository) : ICommandHandler<UpdateSectorCommand, Ulid>
{
    public async Task<Result<Ulid>> Handle(UpdateSectorCommand request, CancellationToken cancellationToken)
    {
        var sector = await repository.FirstOrDefaultAsync(new SectorByIdSpec(request.Id), cancellationToken);
        if (sector is null)
        {
            return Result.Failure<Ulid>(Error.NotFound(SectorMessageKey.SectorNotFound));
        }
        var updatedSector = mapper.Map(request.SectorDto, sector);
        await repository.UpdateAsync(updatedSector, cancellationToken);
        return Result.Success(updatedSector.Id);
    }
}