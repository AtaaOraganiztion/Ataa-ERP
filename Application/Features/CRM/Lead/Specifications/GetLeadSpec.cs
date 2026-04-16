using Application.Features.CRM.Lead.Queries.GetAll;
using Ardalis.Specification;
using Domain.Models.CRM.Lead;

namespace Application.Features.CRM.Lead.Specifications;

public class GetLeadSpec : Specification<Domain.Models.CRM.Lead.Lead>
{
    public GetLeadSpec(LeadFilter filter)
    {
        Query.Include(x => x.Customer)
             .Include(x => x.AssignedTo)
             .Include(x => x.Deals)
             .Include(x => x.Activities);

        if (!string.IsNullOrWhiteSpace(filter.Title))
            Query.Where(x => x.Title.Contains(filter.Title));

        if (filter.Status.HasValue)
            Query.Where(x => x.Status == filter.Status.Value);

        if (filter.Stage.HasValue)
            Query.Where(x => x.Stage == filter.Stage.Value);

        if (filter.CustomerId.HasValue)
            Query.Where(x => x.CustomerId == filter.CustomerId);

        if (filter.AssignedToUserId.HasValue)
            Query.Where(x => x.AssignedToUserId == filter.AssignedToUserId);
    }
}