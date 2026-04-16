using Ardalis.Specification;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

public class ActivityByIdSpec : Specification<Domain.Models.CRM.Activity.Activity>
{
    public ActivityByIdSpec(Ulid id)
    {
        Query.AsSplitQuery()
             .AsTracking()
             .Where(x => x.Id == id)
             .Include(x => x.Customer)
             .Include(x => x.Lead)
             .Include(x => x.Deal)
             .Include(x => x.AssignedTo)
             .Include(x => x.Files); // added
    }
}
