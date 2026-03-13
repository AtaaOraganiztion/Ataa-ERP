using Application.Abstractions.Messaging;
using Domain.Entities;
using Domain.Identities.Event;
using MediatR;
using Microsoft.AspNetCore.Identity;
using SharedKernel;

namespace Application.Features.Identities.Users.Register;

public class RegisterUserCommandHandler(UserManager<Domain.Entities.User> userManager, IMediator mediator)
    : ICommandHandler<RegisterUserCommand>
{
    public async Task<Result> Handle(RegisterUserCommand request, CancellationToken cancellationToken)
    {
        var user = new Domain.Entities.User 
        {
            Id = Ulid.NewUlid(),
            Name = request.Name,
            UserName = request.Email,
            Email = request.Email,
            Phone = request.PhoneNumber,
            NID = request.NID,
            Age = request.Age,
            Gender = request.Gender,
            LastLoginDate = DateTime.Now,
            PhoneNumber = request.PhoneNumber,
            
        };

        IdentityResult result = await userManager.CreateAsync(user, request.Password);

        if (result.Succeeded)
        {
            await userManager.AddToRoleAsync(user, "User");

            await mediator.Publish(new UserRegisteredDomainEvent(user), cancellationToken);

            return Result.Success();
        }

        IEnumerable<Error> errors = result.Errors
            .Select(e => new Error(e.Code, ErrorType.Validation));

        return Result.Failure(new ValidationError([.. errors]));
    }
}
