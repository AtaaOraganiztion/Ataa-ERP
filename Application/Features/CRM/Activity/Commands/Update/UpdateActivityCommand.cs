using Application.Abstractions.Messaging;
using Application.Features.CRM.Activity.Dtos;

namespace Application.Features.CRM.Activity.Commands.Update;

public record UpdateActivityCommand(Ulid Id, UpdateActivityDto Request) : ICommand<Ulid>;