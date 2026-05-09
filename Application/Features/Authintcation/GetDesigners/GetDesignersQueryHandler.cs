using Application.Abstractions.Messaging;
using Application.Abstractions.Repositories;
using Application.Abstractions.Services;
using Application.Features.Identities.Dtos;
using Application.Features.Identities.Specifications;
using Microsoft.AspNetCore.Identity;
using SharedKernel;

namespace Application.Features.Authintcation.GetDesigners;

public class GetDesignersQueryHandler(
    UserManager<Domain.Entities.User> userManager)
    : IQueryHandler<GetDesignersQuery, PaginatedResponse<UserDto>>
{
    public async Task<Result<PaginatedResponse<UserDto>>> Handle(GetDesignersQuery request,
        CancellationToken cancellationToken)
    {
        var designers = await userManager.GetUsersInRoleAsync("Designer");
        
        var query = designers.AsQueryable();

        if (!string.IsNullOrWhiteSpace(request.Filter.Name))
        {
            query = query.Where(u => u.Name != null && u.Name.Contains(request.Filter.Name, StringComparison.OrdinalIgnoreCase));
        }

        if (!string.IsNullOrWhiteSpace(request.Filter.Email))
        {
            query = query.Where(u => u.Email != null && u.Email.Contains(request.Filter.Email, StringComparison.OrdinalIgnoreCase));
        }

        int totalCount = query.Count();

        var users = query
            .OrderBy(u => u.Name)
            .Skip(request.Filter.PageSize * (request.Filter.PageIndex - 1))
            .Take(request.Filter.PageSize)
            .ToList();

        var userDtos = users.Select(u => new UserDto(u.Id,
            u.Name,
            u.Phone ?? string.Empty,
            u.Email ?? string.Empty,
            u.NID,
            u.Age,
            u.Gender,
            u.Status,
            u.LastLoginDate
        )).ToList();


        var paginatedResponse = new PaginatedResponse<UserDto>(
            userDtos,
            totalCount,
            request.Filter.PageIndex,
            request.Filter.PageSize
        );

        return Result.Success(paginatedResponse);
    }
}
