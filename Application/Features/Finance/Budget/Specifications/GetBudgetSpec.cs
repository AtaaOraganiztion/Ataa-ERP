using Application.Features.Budget.Dtos;
using Ardalis.Specification;
using Domain.Entities.Enums;
using Domain.Enums;

namespace Application.Features.Budget.Specifications;

public class GetBudgetSpec : Specification<Domain.Models.Finance.Budget.Budget>
{
    public GetBudgetSpec(BudgetFilter budgetFilter)
    {
        Query.Include(x => x.Sector);

        if (budgetFilter.SectorId is { } sectorId && sectorId != default)
            Query.Where(x => x.SectorId == sectorId);

        if (budgetFilter.Year != default)
            Query.Where(x => x.Year == budgetFilter.Year);

        if (budgetFilter.EstimatedBudget.HasValue)
            Query.Where(x => x.EstimatedBudget == budgetFilter.EstimatedBudget.Value);

        if (budgetFilter.IsConfirmed.HasValue)
            Query.Where(x => x.IsConfirmed == budgetFilter.IsConfirmed.Value);

        if (budgetFilter.Limit.HasValue)
            Query.Where(x => x.Limit == budgetFilter.Limit.Value);

        if (budgetFilter.TotalBudget.HasValue)
            Query.Where(x => x.TotalBudget == budgetFilter.TotalBudget.Value);

        if (budgetFilter.AllocatedAmount.HasValue)
            Query.Where(x => x.AllocatedAmount == budgetFilter.AllocatedAmount.Value);

        if (budgetFilter.SpentAmount.HasValue)
            Query.Where(x => x.SpentAmount == budgetFilter.SpentAmount.Value);

        if (budgetFilter.RemainingAmount.HasValue)
            Query.Where(x => x.RemainingAmount == budgetFilter.RemainingAmount.Value);

        if (budgetFilter.BudgetLimit.HasValue)
            Query.Where(x => x.BudgetLimit == budgetFilter.BudgetLimit.Value);

        if (budgetFilter.Status.HasValue)
            Query.Where(x => x.Status == budgetFilter.Status.Value);

        if (budgetFilter.ConfirmedBy.HasValue)
            Query.Where(x => x.ConfirmedBy == budgetFilter.ConfirmedBy.Value);

        if (budgetFilter.ConfirmedDate.HasValue)
            Query.Where(x => x.ConfirmedDate.Value== budgetFilter.ConfirmedDate.Value.Date);

        if (!string.IsNullOrWhiteSpace(budgetFilter.Notes))
            Query.Where(x => x.Notes!.Contains(budgetFilter.Notes));
    }
}