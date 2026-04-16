using Domain.Entities;

namespace Application.Abstractions.Authentication;

public interface ITokenProvider
{
    (string acessToken, int expiresIn, string tokenType) CreateAccessToken(User user, IList<string> roles);

    (string refreshToken, int expiresIn) GenerateRefreshToken();
}