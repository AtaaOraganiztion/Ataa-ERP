using Ardalis.Specification;

namespace Application.Features.Identities.Specifications;

public class UserByIdSpec : Specification<Domain.Entities.User>
{
    public UserByIdSpec(Ulid id)
    {
        Query.Where(p => p.Id.Equals(id));
    }
    
}