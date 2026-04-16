using Application.Features.CRM.Deal.Queries.GetAll;
using Ardalis.Specification;
using Domain.Models.CRM.Deal;

namespace Application.Features.CRM.Deal.Specifications;

public class GetDealSpec : Specification<Domain.Models.CRM.Deal.Deal>
{
    public GetDealSpec(DealFilter filter)
    {
        Query.Include(x => x.Lead)
             .Include(x => x.AssignedTo);

        if (!string.IsNullOrWhiteSpace(filter.Title))
            Query.Where(x => x.Title.Contains(filter.Title));

        if (filter.Status.HasValue)
            Query.Where(x => x.Status == filter.Status.Value);

        if (filter.LeadId.HasValue)
            Query.Where(x => x.LeadId == filter.LeadId);

        if (filter.AssignedToUserId.HasValue)
            Query.Where(x => x.AssignedToUserId == filter.AssignedToUserId);

        if (filter.MinValue.HasValue)
            Query.Where(x => x.Value >= filter.MinValue.Value);

        if (filter.MaxValue.HasValue)
            Query.Where(x => x.Value <= filter.MaxValue.Value);
    }
}