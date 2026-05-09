using Ardalis.Specification;
using Domain.Models.CRM.GlobalActivity;
using Application.Features.CRM.GlobalActivity.Dtos;

namespace Application.Features.CRM.GlobalActivity.Specifications;

public class GlobalActivitySpec : Specification<Domain.Models.CRM.GlobalActivity.GlobalActivity>
{
    public GlobalActivitySpec(GlobalActivityFilter? filter = null)
    {
        Query.OrderByDescending(a => a.ActivityDate)
             .Include(a => a.Files);

        if (filter == null) return;

        if (filter.Type.HasValue)
            Query.Where(a => a.Type == filter.Type.Value);

        if (filter.Status.HasValue)
            Query.Where(a => a.Status == filter.Status.Value);

        if (filter.CustomerId.HasValue)
            Query.Where(a => a.CustomerId == filter.CustomerId.Value);

        if (filter.LeadId.HasValue)
            Query.Where(a => a.LeadId == filter.LeadId.Value);

        if (filter.DealId.HasValue)
            Query.Where(a => a.DealId == filter.DealId.Value);

        if (filter.FromDate.HasValue)
            Query.Where(a => a.ActivityDate >= filter.FromDate.Value);

        if (filter.ToDate.HasValue)
            Query.Where(a => a.ActivityDate <= filter.ToDate.Value);

        if (filter.ActivityResult.HasValue)
            Query.Where(a => a.ActivityResult == filter.ActivityResult.Value);
    }
}
