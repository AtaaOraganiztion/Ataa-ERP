using Ardalis.Specification;

namespace Application.Features.finance.Budget.Specifications;

public class GetBudgetByIdSpec : Specification<Domain.Models.Finance.Budget.Budget>
{
    public GetBudgetByIdSpec(Ulid id)
    {
        Query.Where(p => p.Id.Equals(id));
    }
}