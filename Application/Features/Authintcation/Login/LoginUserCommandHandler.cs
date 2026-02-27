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

        // 4. Get user roles (take the first role or empty)
        var roles = await userManager.GetRolesAsync(user);
        string role = roles != null && roles.Any() ? roles.First() : string.Empty;

        // 5. Update the user's last login date
        await SetUserLastLoginDate(user);

        // Build user info DTO to include full user data in the response
        var userInfo = new UserInfoDto(
            user.Id,
            user.Name ?? string.Empty,
            user.Email ?? string.Empty,
            user.EmailConfirmed,
            user.PhoneNumber ?? user.Phone ?? string.Empty,
            null, // ProfileImage not available
            user.LockoutEnabled,
            user.LockoutEnd,
            user.LastLoginDate,
            user.NID,
            user.Age ?? 0,
            user.Gender,
            roles ?? new List<string>()
        );

        // 6. Return token + user info
        return Result.Success(new TokenResponseDto(
            accessToken,
            expiresIn,
            tokenType,
            Ulid.NewUlid(),
            userInfo
        ));
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
        user.LastLoginDate = DateTime.UtcNow; 
        await userManager.UpdateAsync(user);
    }
}
