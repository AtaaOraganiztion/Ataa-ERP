using Ardalis.Specification;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

public class LeadByIdSpec : Specification<Domain.Models.CRM.Lead.Lead>
{
    public LeadByIdSpec(Ulid id)
    {
        Query.Where(x => x.Id == id)
             .Include(x => x.Customer)
             .Include(x => x.AssignedTo)
             .Include(x => x.Deals)
             .Include(x => x.Activities);
    }
}