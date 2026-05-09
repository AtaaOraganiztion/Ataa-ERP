using Ardalis.Specification;
using Domain.Models.CRM.GlobalActivity;

namespace Application.Features.CRM.GlobalActivity.Specifications;

public class GlobalActivityByIdSpec : Specification<Domain.Models.CRM.GlobalActivity.GlobalActivity>
{
    public GlobalActivityByIdSpec(Ulid id)
    {
        Query.Where(a => a.Id == id)
             .Include(a => a.Files);
    }
}
