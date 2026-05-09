using Application.Abstractions.Messaging;
using Application.Features.CRM.GlobalActivity.Dtos;

namespace Application.Features.CRM.GlobalActivity.Commands.Update;

public record UpdateGlobalActivityCommand(Ulid Id, UpdateGlobalActivityDto Request) : ICommand<Ulid>;
