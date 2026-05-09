using Ardalis.Specification;

namespace Application.Features.Foras.Specifications;

public class ForasByIdSpec : Specification<Domain.Models.Foras.Foras>
{
    public ForasByIdSpec(Ulid id)
    {
        Query.AsSplitQuery()
             .AsTracking()
             .Where(x => x.Id == id)
             .Include(x => x.Files);
    }
}
