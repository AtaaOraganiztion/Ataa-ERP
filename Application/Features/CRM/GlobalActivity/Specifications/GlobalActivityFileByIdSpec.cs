using Ardalis.Specification;
using Domain.Models.CRM.GlobalActivity;

namespace Application.Features.CRM.GlobalActivity.Specifications;

public class GlobalActivityFileByIdSpec : Specification<Domain.Models.CRM.GlobalActivity.GlobalActivity>
{
    public GlobalActivityFileByIdSpec(Ulid fileId)
    {
        Query
            .Include(a => a.Files)
            .Where(a => a.Files.Any(f => f.Id == fileId));
    }
}
