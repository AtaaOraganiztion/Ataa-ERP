using Application.Abstractions.Messaging;
using Application.Abstractions.Repositories;
using Application.Features.Sector.Dtos;
using Application.Features.Sector.Specifications;
using AutoMapper;
using Domain.Models;
using Domain.Models.Sector;
using SharedKernel;

namespace Application.Features.Sector.Queries.GetById;

public class GetSectorByIdQueryHandler(IRepository<Domain.Models.Sector.Sector> repository, IMapper mapper) : IQueryHandler<GetSectorByIdQuery, GetSectorDto>
{
    public async Task<Result<GetSectorDto>> Handle(GetSectorByIdQuery request, CancellationToken cancellationToken)
    {
        Domain.Models.Sector.Sector? sector = await repository.FirstOrDefaultAsync(new SectorByIdSpec(request.Id), cancellationToken);
        if (sector is null)
        {
            return Result.Failure<GetSectorDto>(Error.NotFound(SectorMessageKey.SectorNotFound));
        }
        GetSectorDto sectorDto = mapper.Map<GetSectorDto>(sector);
        return Result.Success(sectorDto);
    }
}