using Application.Features.Identities.Dtos;
using Ardalis.Specification;
using Domain.Entities;
using SharedKernel;

namespace Application.Features.Identities.Specifications;

public class UserByFilterSpec : Specification<Domain.Entities.User>
{
    public UserByFilterSpec(UserFilter filter)
    {
        Query
            .AsNoTracking()
            .Search(u => u.Name, "%" + filter.Name + "%", !string.IsNullOrWhiteSpace(filter.Name))
            .Search(u => u.Email, "%" + filter.Email + "%", !string.IsNullOrWhiteSpace(filter.Email))
            .Search(u => u.Phone, "%" + filter.PhoneNumber + "%", !string.IsNullOrWhiteSpace(filter.PhoneNumber))
            .OrderBy(u => u.Name)
            .Skip(filter.PageSize * (filter.PageIndex - 1))
            .Take(filter.PageSize);
    }
}
