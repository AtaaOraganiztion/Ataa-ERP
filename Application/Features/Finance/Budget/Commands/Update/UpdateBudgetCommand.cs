using Application.Abstractions.Messaging;
using Application.Features.finance.Budget.Dtos;

namespace Application.Features.finance.Budget.Commands.Update;

public record UpdateBudgetCommand(Ulid Id, UpdateBudgetDto? BudgetDto) : ICommand<Ulid>;
