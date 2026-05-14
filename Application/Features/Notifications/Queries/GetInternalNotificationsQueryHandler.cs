using Application.Abstractions.Authentication;
using Application.Abstractions.Messaging;
using Application.Abstractions.Repositories;
using Application.Features.Notifications.Dtos;
using Application.Features.Notifications.Queries;
using Application.Features.Notifications.Specifications;
using SharedKernel;

namespace Application.Features.Notifications.Queries;

public class GetInternalNotificationsQueryHandler(
    IRepository<Domain.Models.Notifications.Notification> notificationRepository,
    IUserContext userContext)
    : IQueryHandler<GetInternalNotificationsQuery, NotificationsDto>
{
    public async Task<Result<NotificationsDto>> Handle(GetInternalNotificationsQuery request, CancellationToken cancellationToken)
    {
        Ulid currentUserId = userContext.GetUserId();

        var notifications = await notificationRepository.ListAsync(
            new GetNotificationsForUserSpec(currentUserId),
            cancellationToken);

        var unreadCount = await notificationRepository.CountAsync(
            new GetUnreadNotificationsForUserSpec(currentUserId),
            cancellationToken);

        var notificationDtos = notifications
            .Select(notification => new NotificationDto(
                notification.Id,
                notification.Type,
                notification.Title,
                notification.Message,
                notification.EntityType,
                notification.EntityId,
                notification.Link,
                notification.IsRead,
                notification.CreatedAtUtc))
            .ToList();

        var dto = new NotificationsDto(unreadCount, notificationDtos);
        return Result.Success(dto);
    }
}
