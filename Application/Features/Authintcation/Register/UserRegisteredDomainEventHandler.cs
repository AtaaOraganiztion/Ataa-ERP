using Application.Abstractions.Services;
using Domain.Email;
using Domain.Entities;
using Domain.Identities.Event;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Task = System.Threading.Tasks.Task;

namespace Application.Features.Identities.Users.Register;

public class UserRegisteredDomainEventHandler(
    UserManager<Domain.Entities.User> userManager,
    IEmailService emailService)
    : INotificationHandler<UserRegisteredDomainEvent>
{
    public async Task Handle(UserRegisteredDomainEvent notification, CancellationToken cancellationToken)
    {
       
    }
}
