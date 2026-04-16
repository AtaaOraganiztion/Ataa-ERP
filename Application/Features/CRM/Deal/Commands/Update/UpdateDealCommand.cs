using Application.Abstractions.Messaging;
using Application.Features.CRM.Deal.Dtos;

namespace Application.Features.CRM.Deal.Commands.Update;

public record UpdateDealCommand(Ulid Id, UpdateDealDto Request) : ICommand<Ulid>;