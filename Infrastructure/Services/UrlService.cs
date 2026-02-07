using Application.Abstractions.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;

namespace Infrastructure.Services;

public class UrlService(IHttpContextAccessor httpContextAccessor, LinkGenerator linkGenerator) : IUrlService
{
    public string GetGoogleLoginCallbackUrl(string? returnUrl)
    {
        var callbackPath = linkGenerator.GetPathByName(httpContextAccessor.HttpContext!, "GoogleLoginCallback");
        return (string.IsNullOrEmpty(returnUrl) ? callbackPath : $"{callbackPath}?returnUrl={returnUrl}")!;
    }
} 