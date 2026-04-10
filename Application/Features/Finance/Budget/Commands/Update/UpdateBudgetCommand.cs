using Application.Abstractions.Messaging;
using Application.Features.Finance.Budget.Dtos;

namespace Application.Features.Finance.Budget.Commands.Update;

public record UpdateBudgetCommand(Ulid Id, UpdateBudgetDto? BudgetDto) : ICommand<Ulid>;
