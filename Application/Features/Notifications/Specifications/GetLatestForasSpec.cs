using Ardalis.Specification;

namespace Application.Features.Notifications.Specifications;

public class GetLatestForasSpec : Specification<Domain.Models.Foras.Foras>
{
    public GetLatestForasSpec()
    {
        Query.AsSplitQuery()
             .AsNoTracking()
             .Include(x => x.Files)
             .Where(x => !x.IsDeleted)
             .OrderByDescending(x => x.Id)
             .Take(5);
    }
}
