using Application.Abstractions.Messaging;
using Application.Abstractions.Repositories;
using Application.Abstractions.Services;
using Application.Features.Identities.Dtos;
using Application.Features.Identities.Specifications;
using Microsoft.AspNetCore.Identity;
using SharedKernel;

namespace Application.Features.Authintcation.GetUsers;

public class GetUsersQueryHandler(
    IReadRepository<Domain.Entities.User> userRepository,
    UserManager<Domain.Entities.User> userManager,
    IFileService fileService)
    : IQueryHandler<GetUsersQuery, PaginatedResponse<UserDto>>
{
    public async Task<Result<PaginatedResponse<UserDto>>> Handle(GetUsersQuery request,
        CancellationToken cancellationToken)
    {
        List<Domain.Entities.User> users = await userRepository.ListAsync(new UserByFilterSpec(request.Filter), cancellationToken);

        int totalCount = await userRepository.CountAsync(new UserByFilterSpec(request.Filter), cancellationToken);

        var userDtos = users.Select(u => new UserDto(u.Id,
            u.Name,
            u.Email!,
            u.Phone ?? string.Empty,
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
