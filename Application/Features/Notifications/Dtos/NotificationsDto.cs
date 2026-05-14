using SharedKernel;

namespace Application.Features.Notifications.Dtos;

public record NotificationDto(
    Ulid Id,
    string Type,
    string Title,
    string? Message,
    string? EntityType,
    Ulid? EntityId,
    string? Link,
    bool IsRead,
    DateTime CreatedAtUtc
);

public record NotificationsDto(
    int UnreadCount,
    List<NotificationDto> Notifications
);
