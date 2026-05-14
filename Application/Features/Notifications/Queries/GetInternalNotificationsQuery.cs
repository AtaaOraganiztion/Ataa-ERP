using Application.Abstractions.Messaging;
using Application.Features.Notifications.Dtos;

namespace Application.Features.Notifications.Queries;

public record GetInternalNotificationsQuery() : IQuery<NotificationsDto>;
