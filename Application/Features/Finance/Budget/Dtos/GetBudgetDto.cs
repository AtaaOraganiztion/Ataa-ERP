using Domain.Entities.Enums;
using Domain.Enums;

namespace Application.Features.Budget.Dtos;

public record GetBudgetDto(
    Ulid Id,
    Ulid? SectorId,
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
    Ulid? ConfirmedBy,
    DateTime? ConfirmedDate,
    string? Notes
);