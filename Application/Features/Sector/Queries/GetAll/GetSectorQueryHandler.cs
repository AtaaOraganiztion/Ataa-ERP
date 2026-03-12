using Application.Abstractions.Messaging;
using Application.Abstractions.Repositories;
using Application.Features.Sector.Dtos;
using Application.Features.Sector.Specifications;

using AutoMapper;
using SharedKernel;

namespace Application.Features.Sector.Queries.GetAll;

public class GetSectorQueryHandler(IRepository<Domain.Models.Sector.Sector> repository, IMapper mapper) : IQueryHandler<GetSectorQuery, List<GetSectorDto>>
{
    public async Task<Result<List<GetSectorDto>>> Handle(GetSectorQuery request, CancellationToken cancellationToken)
    {
        List<Domain.Models.Sector.Sector> sectors = await repository.ListAsync(
            new GetSectorSpec(request.SectorFilter),
            cancellationToken);
            
        List<GetSectorDto> sectorDtos = mapper.Map<List<GetSectorDto>>(sectors);
        return Result.Success(sectorDtos);
    }
}