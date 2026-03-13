using Application.Abstractions.Messaging;
using Application.Abstractions.Repositories;
using Application.Features.User.Dtos;
using Application.Features.User.Specifications;

using AutoMapper;
using SharedKernel;

namespace Application.Features.User.Queries.GetAll;

public class GetUserQueryHandler(IRepository<Domain.Entities.User> repository, IMapper mapper) : IQueryHandler<GetUserQuery, List<GetUserDto>>
{
    public async Task<Result<List<GetUserDto>>> Handle(GetUserQuery request, CancellationToken cancellationToken)
    {
        List<Domain.Entities.User> budgets = await repository.ListAsync(
            new GetUserSpec(request.BudgetFilter),
            cancellationToken);

        List<GetUserDto> contactFormDtos = mapper.Map<List<GetUserDto>>(budgets);
        return Result.Success(contactFormDtos);
    }
}