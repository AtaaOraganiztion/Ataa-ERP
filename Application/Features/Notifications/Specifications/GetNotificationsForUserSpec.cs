using Ardalis.Specification;
using Domain.Models.Notifications;

namespace Application.Features.Notifications.Specifications;

public class GetNotificationsForUserSpec : Specification<Notification>
{
    public GetNotificationsForUserSpec(Ulid currentUserId, int take = 20)
    {
        Query.AsNoTracking()
             .OrderByDescending(x => x.CreatedAtUtc)
             .Where(x => x.UserId == currentUserId || x.UserId == null)
             .Take(take);
    }
}
