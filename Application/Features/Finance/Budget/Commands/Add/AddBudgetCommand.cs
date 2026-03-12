using Application.Abstractions.Messaging;
using Domain.Entities.Enums;
using Domain.Enums;

namespace Application.Features.Budget.Commands.Add;

public record AddBudgetCommand(
 Guid? SectorId,
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
 Guid? ConfirmedBy ,
 DateTime? ConfirmedDate,
 string Notes 
    ) : ICommand<Ulid>;