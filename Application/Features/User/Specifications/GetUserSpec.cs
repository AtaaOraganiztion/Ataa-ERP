using Application.Features.User.Dtos;
using Ardalis.Specification;
using Domain.Entities.Enums;
using Domain.Enums;

namespace Application.Features.User.Specifications;

public class GetUserSpec : Specification<Domain.Entities.User>
{
    public GetUserSpec(UserFilter userFilter)
    {
        if (userFilter.UserId != default)
            Query.Where(x => x.Id == userFilter.UserId);

        if (!string.IsNullOrWhiteSpace(userFilter.Name))
            Query.Where(x => x.Name!.Contains(userFilter.Name));

        if (!string.IsNullOrWhiteSpace(userFilter.Phone))
            Query.Where(x => x.Phone!.Contains(userFilter.Phone));

        if (!string.IsNullOrWhiteSpace(userFilter.NID))
            Query.Where(x => x.NID!.Contains(userFilter.NID));

        if (userFilter.Age.HasValue)
            Query.Where(x => x.Age == userFilter.Age.Value);

        if (userFilter.Gender.HasValue)
            Query.Where(x => x.Gender == userFilter.Gender.Value);

        if (userFilter.Status != default)
            Query.Where(x => x.Status == userFilter.Status);

        if (userFilter.LastLoginDate.HasValue)
            Query.Where(x => x.LastLoginDate.HasValue &&
                             x.LastLoginDate.Value.Date == userFilter.LastLoginDate.Value.Date);
    }
}