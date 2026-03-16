using Application.Abstractions.Authentication;
using Application.Abstractions.Messaging;
using Application.Features.Identities.Users.UpdateUser;
using Domain.Entities;
using Domain.Identities;
using Microsoft.AspNetCore.Identity;
using SharedKernel;

namespace Application.Features.Identities.Users.UpdateMe;

public class UpdateMeCommandHandler(UserManager<Domain.Entities.User> userManager, IUserContext userContext) : ICommandHandler<UpdateMeCommand>
{
    public async Task<Result> Handle(UpdateMeCommand request, CancellationToken cancellationToken)
    {
        Ulid userId = userContext.GetUserId();
        Domain.Entities.User? user = await userManager.FindByIdAsync(userId.ToString());

        if (user is null)
        {
            return Result.Failure(Error.NotFound(IdentityMessageKeys.UserNotFound));
        }

        user.Name = request.UpdateUserDto.Name;
        user.Phone = request.UpdateUserDto.PhoneNumber;

        IdentityResult result = await userManager.UpdateAsync(user);
        if (result.Succeeded)
        {
            return Result.Success();
        }

        IEnumerable<Error> errors = result.Errors
            .Select(e => new Error(e.Code, ErrorType.Validation));

        return Result.Failure(new ValidationError([.. errors]));
    }
}
