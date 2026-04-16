using Application.Abstractions.Messaging;
using Application.Abstractions.Repositories;
using AutoMapper;
using Domain.Models.CRM.Deal;
using SharedKernel;

namespace Application.Features.CRM.Deal.Commands.Update;

public class UpdateDealCommandHandler(
    IMapper mapper,
    IRepository<Domain.Models.CRM.Deal.Deal> repository)
    : ICommandHandler<UpdateDealCommand, Ulid>
{
    public async Task<Result<Ulid>> Handle(UpdateDealCommand request, CancellationToken cancellationToken)
    {
        var deal = await repository.GetByIdAsync(request.Id, cancellationToken);
        if (deal is null)
            return Result.Failure<Ulid>(Error.NotFound(DealMessageKeys.DealNotFound));

        mapper.Map(request.Request, deal);
        await repository.UpdateAsync(deal, cancellationToken);
        return Result.Success(deal.Id);
    }
}