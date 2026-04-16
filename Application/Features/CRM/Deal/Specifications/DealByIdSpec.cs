using Ardalis.Specification;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

public class DealByIdSpec : Specification<Domain.Models.CRM.Deal.Deal>
{
    public DealByIdSpec(Ulid id)
    {
        Query.Where(x => x.Id == id)
             .Include(x => x.Lead)
             .Include(x => x.AssignedTo);
    }
}