using Application.Abstractions.Messaging;
using Domain.Entities.Enums;
using Domain.Enums;

namespace Application.Features.finance.Budget.Commands.Add;

public record AddBudgetCommand(
 Ulid? SectorId,
 int Year,
 decimal EstimatedBudget,
 bool IsConfirmed,
 decimal Limit,
 decimal TotalBudget ,
 decimal AllocatedAmount ,
 decimal SpentAmount ,
 decimal RemainingAmount ,
 decimal BudgetLimit ,
 BudgetStatus Status,
 Ulid? ConfirmedBy ,
 DateTime? ConfirmedDate,
 string Notes 
    ) : ICommand<Ulid>;