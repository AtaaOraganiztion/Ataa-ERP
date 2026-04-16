using Ardalis.Specification;
using Domain.Models.CRM.Activity;
namespace Application.Features.CRM.Activity.Specifications;

public class ActivityFileByIdSpec : Specification<Domain.Models.CRM.Activity.Activity>
{
    public ActivityFileByIdSpec(Ulid fileId)
    {
        Query
            .Include(a => a.Files)
            .Where(a => a.Files.Any(f => f.Id == fileId));
    }
}