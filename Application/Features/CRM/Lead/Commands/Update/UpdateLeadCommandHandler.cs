using Application.Abstractions.Messaging;
using Application.Abstractions.Repositories;
using AutoMapper;
using Domain.Models.CRM.Lead;
using SharedKernel;

namespace Application.Features.CRM.Lead.Commands.Update;

public class UpdateLeadCommandHandler(
    IMapper mapper,
    IRepository<Domain.Models.CRM.Lead.Lead> repository)
    : ICommandHandler<UpdateLeadCommand, Ulid>
{
    public async Task<Result<Ulid>> Handle(UpdateLeadCommand request, CancellationToken cancellationToken)
    {
        var lead = await repository.GetByIdAsync(request.Id, cancellationToken);
        if (lead is null)
            return Result.Failure<Ulid>(Error.NotFound(LeadMessageKeys.LeadNotFound));

        mapper.Map(request.Request, lead);
        await repository.UpdateAsync(lead, cancellationToken);
        return Result.Success(lead.Id);
    }
}