using Application.Abstractions.Messaging;
using Application.Abstractions.Repositories;
using Application.Abstractions.Authentication;
using Application.Features.Notifications.Queries;
using SharedKernel;

namespace Application.Features.Notifications.Commands;

public class MarkNotificationAsReadCommandHandler(
    IRepository<Domain.Models.Notifications.Notification> repository,
    IUserContext userContext)
    : ICommandHandler<MarkNotificationAsReadCommand, Ulid>
{
    public async Task<Result<Ulid>> Handle(MarkNotificationAsReadCommand request, CancellationToken cancellationToken)
    {
        Ulid currentUserId = userContext.GetUserId();
        var notification = await repository.GetByIdAsync(request.Id, cancellationToken);

        if (notification is null)
            return Result.Failure<Ulid>(Error.NotFound("Notification not found."));

        if (notification.UserId is not null && notification.UserId != currentUserId)
            return Result.Failure<Ulid>(Error.Unauthorized("Notification does not belong to the current user."));

        notification.IsRead = true;
        await repository.UpdateAsync(notification, cancellationToken);

        return Result.Success(request.Id);
    }
}
