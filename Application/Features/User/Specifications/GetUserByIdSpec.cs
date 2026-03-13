using Ardalis.Specification;

namespace Application.Features.User.Specifications;

public class UserByIdSpec : Specification<Domain.Entities.User>
{
    public UserByIdSpec(Ulid id)
    {
        Query.Where(p => p.Id.Equals(id));
    }
}