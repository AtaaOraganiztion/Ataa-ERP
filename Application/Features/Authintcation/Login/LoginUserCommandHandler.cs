using Application.Abstractions.Authentication;
using Application.Abstractions.Messaging;
using Application.Features.Identities.Dtos;
using Domain.Entities;
using Domain.Identities;
using Microsoft.AspNetCore.Identity;
using SharedKernel;
using System.Security.Claims;

namespace Application.Features.Identities.Users.Login;

public class LoginUserCommandHandler(
    UserManager<Domain.Entities.User> userManager,
    ITokenProvider tokenProvider)
    : ICommandHandler<LoginUserCommand, TokenResponseDto>
{
    public async Task<Result<TokenResponseDto>> Handle(LoginUserCommand request, CancellationToken cancellationToken)
    {
        // 1. Find user
        var user = await userManager.FindByEmailAsync(request.Email);

        // 2. Validate credentials
        if (user == null || !await userManager.CheckPasswordAsync(user, request.Password))
        {
            return Result.Failure<TokenResponseDto>(Error.Unauthorized(IdentityMessageKeys.InvalidCredentials));
        }

        // 3. Get roles ✅ IMPORTANT
        var roles = await userManager.GetRolesAsync(user);

        // 4. Generate token WITH roles ✅
        (string accessToken, int expiresIn, string tokenType) =
            tokenProvider.CreateAccessToken(user, roles);

        // 5. Update last login
        await SetUserLastLoginDate(user);

        // 6. Build response
        var userInfo = new UserInfoDto(
            user.Id,
            user.Name ?? string.Empty,
            user.Email ?? string.Empty,
            user.EmailConfirmed,
            user.PhoneNumber ?? user.Phone ?? string.Empty,
            null,
            user.LockoutEnabled,
            user.LockoutEnd,
            user.LastLoginDate,
            user.NID,
            user.Age ?? 0,
            user.Gender,
            roles // ✅ now always filled
        );

        return Result.Success(new TokenResponseDto(
            accessToken,
            expiresIn,
            tokenType,
            Ulid.NewUlid(),
            userInfo
        ));
    }

    private async Task SetUserLastLoginDate(Domain.Entities.User user)
    {
        user.LastLoginDate = DateTime.UtcNow;
        await userManager.UpdateAsync(user);
    }
}