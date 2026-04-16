using Ardalis.Specification;

namespace Application.Features.Identities.Specifications;

public class UserByIdSpec : Specification<Domain.Entities.User>
{
    public UserByIdSpec(Ulid id)
    {
        Query
           
            .Where(u => u.Id == id);
    }
}