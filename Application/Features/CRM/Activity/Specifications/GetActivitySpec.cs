using Application.Features.CRM.Activity.Queries.GetAll;
using Ardalis.Specification;
using Domain.Models.CRM.Activity;
using Application.Features.CRM.Activity.Dtos;

namespace Application.Features.CRM.Activity.Specifications;

public class GetActivitySpec : Specification<Domain.Models.CRM.Activity.Activity>
{
    public GetActivitySpec(ActivityFilter filter)
    {
        Query.AsSplitQuery()
             .AsTracking();

        // Includes
        Query.Include(x => x.Customer)
             .Include(x => x.Lead)
             .Include(x => x.Deal)
             .Include(x => x.AssignedTo)
             .Include(x => x.Files); // added

        // Filters
        if (filter.Type.HasValue)
            Query.Where(x => x.Type == filter.Type.Value);

        if (filter.Status.HasValue)
            Query.Where(x => x.Status == filter.Status.Value);

        if (filter.CustomerId.HasValue)
            Query.Where(x => x.CustomerId == filter.CustomerId);

        if (filter.LeadId.HasValue)
            Query.Where(x => x.LeadId == filter.LeadId);

        if (filter.DealId.HasValue)
            Query.Where(x => x.DealId == filter.DealId);

        if (filter.AssignedToUserId.HasValue)
            Query.Where(x => x.AssignedToUserId == filter.AssignedToUserId);

        if (filter.FromDate.HasValue)
            Query.Where(x => x.ActivityDate >= filter.FromDate.Value);

        if (filter.ToDate.HasValue)
            Query.Where(x => x.ActivityDate <= filter.ToDate.Value);
    }
}
