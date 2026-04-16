using Application.Abstractions.Messaging;
using Application.Abstractions.Repositories;
using SharedKernel;
using Domain.Models.CRM.Lead;

namespace Application.Features.CRM.Lead.Commands.Delete;

public class DeleteLeadCommandHandler(
    IRepository<Domain.Models.CRM.Lead.Lead> repository)
    : ICommandHandler<DeleteLeadCommand, Ulid>
{
    public async Task<Result<Ulid>> Handle(DeleteLeadCommand request, CancellationToken cancellationToken)
    {
        var lead = await repository.GetByIdAsync(request.Id, cancellationToken);
        if (lead is null)
            return Result.Failure<Ulid>(Error.NotFound(LeadMessageKeys.LeadNotFound));

        await repository.DeleteAsync(lead, cancellationToken);
        return Result.Success(lead.Id);
    }
}