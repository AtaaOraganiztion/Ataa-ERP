using Ardalis.Specification;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

public class CustomerByIdSpec : Specification<Domain.Models.CRM.Customer.Customer>
{
    public CustomerByIdSpec(Ulid id)
    {
        Query.Where(x => x.Id == id)
             .Include(x => x.AssignedTo)
             .Include(x => x.Leads)
             .Include(x => x.Activities);
    }
}