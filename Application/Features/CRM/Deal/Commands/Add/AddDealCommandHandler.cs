using Application.Abstractions.Messaging;
using Application.Abstractions.Repositories;
using AutoMapper;
using SharedKernel;

namespace Application.Features.CRM.Deal.Commands.Add;

public class AddDealCommandHandler(
    IMapper mapper,
    IRepository<Domain.Models.CRM.Deal.Deal> repository)
    : ICommandHandler<AddDealCommand, Ulid>
{
    public async Task<Result<Ulid>> Handle(AddDealCommand request, CancellationToken cancellationToken)
    {
        var deal = mapper.Map<Domain.Models.CRM.Deal.Deal>(request);
        await repository.AddAsync(deal, cancellationToken);
        return Result.Success(deal.Id);
    }
}