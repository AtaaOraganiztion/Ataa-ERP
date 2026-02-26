using Application.Abstractions.Messaging;
using Domain.Entities;
using Domain.Identities;
using Microsoft.AspNetCore.Identity;
using SharedKernel;

namespace Application.Features.Identities.Users.UpdateUser;

public class UpdateUserCommandHandler(UserManager<User> userManager) : ICommandHandler<UpdateUserCommand>
{
    public async Task<Result> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
    {
        User? user = await userManager.FindByIdAsync(request.UserId.ToString());

        if (user is null)
        {
            return Result.Failure(Error.NotFound(IdentityMessageKeys.UserNotFound));
        }

        user.Name = request.UpdateUserDto.Name;
        user.Phone = request.UpdateUserDto.PhoneNumber;
        user.NID = request.UpdateUserDto.NID;
        user.Email = request.UpdateUserDto.Email;
        user.UserName = request.UpdateUserDto.Email;
        user.Age = request.UpdateUserDto.Age;
        user.Gender = request.UpdateUserDto.Gender;
        
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
