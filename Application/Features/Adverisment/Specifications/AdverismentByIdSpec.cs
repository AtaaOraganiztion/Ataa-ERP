using Ardalis.Specification;

namespace Application.Features.Adverisment.Specifications;

public class AdverismentByIdSpec : Specification<Domain.Models.Adverisment.Adverisment>
{
    public AdverismentByIdSpec(Ulid id)
    {
        Query.AsSplitQuery()
             .AsTracking()
             .Where(x => x.Id == id)
             .Include(x => x.Files);
    }
}