using Application.Abstractions.Messaging;
using Application.Features.Budget.Dtos;

namespace Application.Features.Budget.Commands.Update;

public record UpdateBudgetCommand(Ulid Id, UpdateBudgetDto? BudgetDto) : ICommand<Ulid>;
