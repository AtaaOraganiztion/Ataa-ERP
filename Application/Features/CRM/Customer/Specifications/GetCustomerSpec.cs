using Application.Features.CRM.Customer.Dtos;
using Ardalis.Specification;
using Domain.Models.CRM.Customer;

namespace Application.Features.CRM.Customer.Specifications;

public class GetCustomerSpec : Specification<Domain.Models.CRM.Customer.Customer>
{
    public GetCustomerSpec(CustomerFilter filter)
    {
        Query.Include(x => x.AssignedTo)
             .Include(x => x.Leads)
             .Include(x => x.Activities);

        if (!string.IsNullOrWhiteSpace(filter.FullName))
            Query.Where(x => x.FullName.Contains(filter.FullName));

        if (!string.IsNullOrWhiteSpace(filter.Email))
            Query.Where(x => x.Email.Contains(filter.Email));

        if (!string.IsNullOrWhiteSpace(filter.Company))
            Query.Where(x => x.Company.Contains(filter.Company));

        if (filter.Status.HasValue)
            Query.Where(x => x.Status == filter.Status.Value);

        if (filter.AssignedToUserId.HasValue)
            Query.Where(x => x.AssignedToUserId == filter.AssignedToUserId);
    }
}