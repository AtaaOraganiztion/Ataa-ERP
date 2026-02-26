namespace Application.Features.Identities.Dtos;

public record UserDeviceDto(
    Ulid Id,
    string DeviceId,
    string DeviceName,
    string DeviceType,
    string? Browser,
    string? IpAddress,
    DateTime LoginDate,
    DateTime? LastActivityDate,
    bool IsActive,
    DateTime? TokenExpiryDate
);
