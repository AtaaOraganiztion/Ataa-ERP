using Ardalis.Specification;
using Domain.Entities;
using Domain.Entities.Enums;

namespace Application.Features.Attendance.Specifications;

public class ActiveUsersSpec : Specification<Domain.Entities.User>
{
    public ActiveUsersSpec()
    {
        Query.Where(u => u.Status == UserStatus.Active);
    }
}
