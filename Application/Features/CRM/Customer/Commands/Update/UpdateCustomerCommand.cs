using Application.Abstractions.Messaging;
using Application.Features.CRM.Customer.Dtos;

namespace Application.Features.CRM.Customer.Commands.Update;

public record UpdateCustomerCommand(Ulid Id, UpdateCustomerDto Request) : ICommand<Ulid>;