using Application.Abstractions.Messaging;
using Application.Features.CRM.Lead.Dtos;

namespace Application.Features.CRM.Lead.Commands.Update;

public record UpdateLeadCommand(Ulid Id, UpdateLeadDto Request) : ICommand<Ulid>;