namespace Application.Abstractions.Services;

public interface IUrlService
{
    string GetGoogleLoginCallbackUrl(string? returnUrl);
} 