using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using Application.Abstractions.Authentication;
using Domain.Identities.Entities;
using Infrastructure.Settings;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.JsonWebTokens;
using Microsoft.IdentityModel.Tokens;
using SharedKernel;
using Claim = System.Security.Claims.Claim;

namespace Infrastructure.Authentication;

internal sealed class TokenProvider(JwtSetting jwtSetting, UserManager<User> userManager) : ITokenProvider
{
    public (string acessToken, int expiresIn, string tokenType) CreateAccessToken(User user)
    {
        var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtSetting.Key));
        var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

        var claims = new List<Claim>
        {
            new(ClaimTypes.NameIdentifier, user.Id.ToString()),
            new(ClaimTypes.Name, user.Email ?? string.Empty),
            new(ClaimTypes.Email, user.Email ?? string.Empty),
            new(JwtRegisteredClaimNames.Sub, user.Id.ToString()),
            new(JwtRegisteredClaimNames.Email, user.Email ?? string.Empty),
            new(JwtRegisteredClaimNames.Jti, Ulid.NewUlid().ToString()),
        };

        // Add user roles as claims
        var roles = userManager.GetRolesAsync(user).GetAwaiter().GetResult();
        claims.AddRange(roles.Select(role => new Claim(ClaimTypes.Role, role)));

        var tokenDescriptor = new SecurityTokenDescriptor
        {
            Subject = new ClaimsIdentity(claims),
            Expires = SystemClock.Now.AddMinutes(jwtSetting.ExpiresIn),
            SigningCredentials = credentials,
            Issuer = jwtSetting.Issuer,
            Audience = jwtSetting.Audience,
            IssuedAt = SystemClock.Now,
        };

        var handler = new JsonWebTokenHandler();
        string token = handler.CreateToken(tokenDescriptor);

        return (token, jwtSetting.ExpiresIn, "Bearer");
    }

    public (string refreshToken, int expiresIn) GenerateRefreshToken()
    {
        return (Convert.ToBase64String(RandomNumberGenerator.GetBytes(64)), jwtSetting.RefreshExpiresIn);
    }
}
