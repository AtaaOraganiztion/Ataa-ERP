
using Domain.Entities.Enums;
using Domain.Enums;

namespace Application.Features.Budget.Dtos;

public record UpdateBudgetDto(
     Guid? SectorId,
    int Year,
    decimal? EstimatedBudget,
    bool? IsConfirmed,
    decimal? Limit,
    decimal? TotalBudget,
    decimal? AllocatedAmount,
    decimal? SpentAmount,
    decimal? RemainingAmount,
    decimal? BudgetLimit,
    BudgetStatus? Status,
    Guid? ConfirmedBy,
    DateTime? ConfirmedDate,
    string? Notes
    );