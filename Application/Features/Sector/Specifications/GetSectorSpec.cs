using Application.Features.Employee.Dtos;
using Application.Features.Sector.Dtos;
using Ardalis.Specification;

namespace Application.Features.Sector.Specifications;

public class GetSectorSpec : Specification<Domain.Models.Sector.Sector>
{
    public GetSectorSpec(SectorFilter sectorFilter)
    {

        if (!string.IsNullOrWhiteSpace(sectorFilter.Name))
            Query.Where(x => x.Name.Contains(sectorFilter.Name));

        if (!string.IsNullOrWhiteSpace(sectorFilter.Description))
            Query.Where(x => x.Description.Contains(sectorFilter.Description));
        
        if (sectorFilter.ManagerUserId is { } managerUserId && managerUserId != default)
            Query.Where(x => x.ManagerUserId == managerUserId);

        if (sectorFilter.ParentSectorId is { } parentSectorId && parentSectorId != default)
            Query.Where(x => x.ParentSectorId == parentSectorId);
    }
}