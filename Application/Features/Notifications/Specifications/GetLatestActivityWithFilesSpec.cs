using Ardalis.Specification;
using Domain.Models.CRM.Activity;

namespace Application.Features.Notifications.Specifications;

public class GetLatestActivityWithFilesSpec : Specification<Activity>
{
    public GetLatestActivityWithFilesSpec(Ulid currentUserId)
    {
        Query.AsSplitQuery()
             .AsNoTracking()
             .Include(x => x.Files)
             .Where(x => x.Files.Any(f => f.CreatedByUserId == currentUserId) || x.CreatedByUserId == currentUserId)
             .OrderByDescending(x => x.Id)
             .Take(5);
    }
}
