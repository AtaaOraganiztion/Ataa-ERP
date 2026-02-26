using Application.Abstractions.Authentication;
using Application.Abstractions.Messaging;
using Application.Features.Identities.Dtos;
using Domain.Entities;
using Domain.Identities;
using Microsoft.AspNetCore.Identity;
using SharedKernel;
using Task = System.Threading.Tasks.Task;

namespace Application.Features.Identities.Users.Login;

public class LoginUserCommandHandler(
    UserManager<User> userManager,
    ITokenProvider tokenProvider)
    : ICommandHandler<LoginUserCommand, TokenResponseDto>
{
    private const int MaxDevicesPerUser = 2;

    public async Task<Result<TokenResponseDto>> Handle(LoginUserCommand request, CancellationToken cancellationToken)
    {
        // 1. Find the user by email
        User? user = await userManager.FindByEmailAsync(request.Email);

        // 2. Check if the user exists and if the password is correct
        if (user == null || !await userManager.CheckPasswordAsync(user, request.Password))
        {
            return Result.Failure<TokenResponseDto>(Error.Unauthorized(IdentityMessageKeys.InvalidCredentials));
        }

        // 3. Generate access token to get expiry info
        (string accessToken, int expiresIn, string tokenType) =
            tokenProvider.CreateAccessToken(user);

        // 4. Check if this device is already registered for this user
        

        // 5. Update the user's last login date
        await SetUserLastLoginDate(user);

        return Result.Success(new TokenResponseDto(accessToken, expiresIn,
            tokenType, Ulid.NewUlid()));
    }
    

    private static Result<TokenResponseDto> HandleSignInResult(SignInResult result)
    {
        if (result.IsLockedOut)
        {
            return Result.Failure<TokenResponseDto>(Error.Invalid(IdentityMessageKeys.LockoutEnabled));
        }

        if (result.IsNotAllowed)
        {
            return Result.Failure<TokenResponseDto>(Error.Invalid(IdentityMessageKeys.EmailNotConfirmed));
        }

        return Result.Failure<TokenResponseDto>(Error.Invalid(IdentityMessageKeys.SignInError));
    }

    private async Task SetUserLastLoginDate(User user)
    {
        await userManager.UpdateAsync(user);
    }
}
