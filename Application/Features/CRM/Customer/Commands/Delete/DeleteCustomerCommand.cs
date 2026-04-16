using Application.Abstractions.Messaging;

namespace Application.Features.CRM.Customer.Commands.Delete;

public record DeleteCustomerCommand(Ulid Id) : ICommand<Ulid>;