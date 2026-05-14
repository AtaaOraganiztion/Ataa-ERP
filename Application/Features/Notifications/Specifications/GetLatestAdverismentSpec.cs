using Ardalis.Specification;

namespace Application.Features.Notifications.Specifications;

public class GetLatestAdverismentSpec : Specification<Domain.Models.Adverisment.Adverisment>
{
    public GetLatestAdverismentSpec()
    {
        Query.AsSplitQuery()
             .AsNoTracking()
             .Include(x => x.Files)
             .Where(x => !x.IsDeleted)
             .OrderByDescending(x => x.Id)
             .Take(5);
    }
}
