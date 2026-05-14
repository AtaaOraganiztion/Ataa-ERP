    using Ardalis.Specification;
using Domain.Models.Notifications;

namespace Application.Features.Notifications.Specifications;

public class GetUnreadNotificationsForUserSpec : Specification<Notification>
{
    public GetUnreadNotificationsForUserSpec(Ulid currentUserId)
    {
        Query.AsNoTracking()
             .Where(x => !x.IsRead && (x.UserId == currentUserId || x.UserId == null));
    }
}
