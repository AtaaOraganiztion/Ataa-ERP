using Ardalis.Specification;

namespace Application.Features.Sector.Specifications;

public class SectorByIdSpec : Specification<Domain.Models.Sector.Sector>
{
    public SectorByIdSpec(Ulid id)
    {
        Query.Where(p => p.Id.Equals(id));
        Query.Include(x => x.Employees);
    }
}