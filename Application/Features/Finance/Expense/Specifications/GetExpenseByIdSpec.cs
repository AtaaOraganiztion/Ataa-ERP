using Ardalis.Specification;

namespace Application.Features.Finance.Expense.Specifications;

public class GetExpenseByIdSpec : Specification<Domain.Models.Finance.Expense.Expense>
{
    public GetExpenseByIdSpec(Ulid id)
    {
        Query.Include(x => x.Sector);
        Query.Include(x => x.Project);
        Query.Include(x => x.Requester);
        Query.Include(x => x.Approver);
        Query.Include(x => x.Confirmer);

        Query.Where(x => x.Id == id);
    }
}