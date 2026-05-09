using Application.Features.Identities.Dtos;
using Ardalis.Specification;
using Domain.Entities;
using SharedKernel;

namespace Application.Features.Identities.Specifications;

public class DesignersSpec : Specification<Domain.Entities.User>
{
    public DesignersSpec(UserFilter filter)
    {
        Query
            .AsNoTracking()
            .Include(u => u.UserRoles)
                .ThenInclude(ur => ur.Role)
            .Where(u => u.UserRoles.Any(ur => ur.Role.Name == "Designer" || ur.Role.NormalizedName == "DESIGNER"))
            .Search(u => u.Name, "%" + filter.Name + "%", !string.IsNullOrWhiteSpace(filter.Name))
            .Search(u => u.Email, "%" + filter.Email + "%", !string.IsNullOrWhiteSpace(filter.Email))
            .OrderBy(u => u.Name)
            .ThenBy(u => u.Id)
            .Skip(filter.PageSize * (filter.PageIndex - 1))
            .Take(filter.PageSize);
    }
}
