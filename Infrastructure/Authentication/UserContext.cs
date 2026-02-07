using System.Security.Claims;
using Application.Abstractions.Authentication;
using Microsoft.AspNetCore.Http;

namespace Infrastructure.Authentication;

public class UserContext(IHttpContextAccessor httpContextAccessor) : IUserContext
{
    public Ulid GetUserId()
    {
        string userId = httpContextAccessor
            .HttpContext?
            .User
            .GetUserId() ?? throw new ApplicationException("User context is unavailable");

        return Ulid.Parse(userId);
    }

    public bool CanBypassOwnershipCheck()
    {
        Claim? claim = httpContextAccessor
            .HttpContext?
            .User
            .Claims
            .FirstOrDefault(c => c.Type == "canByPassOwnershipCheck");

        if (claim == null)
        {
            return false;
        }

        string canBypassOwnershipCheck = claim.Value;

        return bool.TryParse(canBypassOwnershipCheck, out bool result) && result;
    }

    public bool CanBypassDeletedCheck()
    {
        Claim? claim = httpContextAccessor
            .HttpContext?
            .User
            .Claims
            .FirstOrDefault(c => c.Type == "canBypassDeletedCheck");

        if (claim == null)
        {
            return false;
        }

        string canBypassDeletedCheck = claim.Value;

        return bool.TryParse(canBypassDeletedCheck, out bool result) && result;
    }
}
