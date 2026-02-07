namespace Domain.Identities;

public static class IdentityMessageKeys
{
    public const string UserNotFound = "Usernotfound";
    public const string InvalidCredentials = "InvalidCredentials";
    public const string LockoutEnabled = "LockoutEnabled";
    public const string EmailNotConfirmed = "EmailNotConfirmed";
    public const string RoleNotFound = "RoleNotFound";
    public const string ClaimsNotFound = "ClaimsNotFound";
    public const string SignInError = "SignInError";
    public const string EmailAlreadyConfirmed = "EmailAlreadyConfirmed";
    public const string InvalidConfirmationCode = "InvalidConfirmationCode";
    public const string RefreshTokenCantBeUsed = "RefreshTokenCantBeUsed";
    
    // Device management
    public const string DeviceNotFound = "DeviceNotFound";
    public const string MaxDevicesReached = "MaxDevicesReached";
    public const string DeviceLimitExceeded = "DeviceLimitExceeded";
}
