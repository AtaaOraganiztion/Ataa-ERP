using Application.Abstractions.Messaging;
using Application.Abstractions.Repositories;
using Domain.Models.CRM.Deal;
using SharedKernel;

namespace Application.Features.CRM.Deal.Commands.Delete;

public class DeleteDealCommandHandler(
    IRepository<Domain.Models.CRM.Deal.Deal> repository)
    : ICommandHandler<DeleteDealCommand, Ulid>
{
    public async Task<Result<Ulid>> Handle(DeleteDealCommand request, CancellationToken cancellationToken)
    {
        var deal = await repository.GetByIdAsync(request.Id, cancellationToken);
        if (deal is null)
            return Result.Failure<Ulid>(Error.NotFound(DealMessageKeys.DealNotFound));

        await repository.DeleteAsync(deal, cancellationToken);
        return Result.Success(deal.Id);
    }
}