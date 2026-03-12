using Ardalis.Specification;

namespace Application.Features.Budget.Specifications;

public class BudgetByIdSpec : Specification<Domain.Models.Finance.Budget.Budget>
{
    public BudgetByIdSpec(Ulid id)
    {
        Query.Where(p => p.Id.Equals(id));
    }
}