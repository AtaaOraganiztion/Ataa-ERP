
using Domain.Entities;

namespace Application.Abstractions.Authentication;

public interface ITokenProvider
{
    (string acessToken, int expiresIn, string tokenType) CreateAccessToken(User user);

    (string refreshToken, int expiresIn) GenerateRefreshToken();
}
