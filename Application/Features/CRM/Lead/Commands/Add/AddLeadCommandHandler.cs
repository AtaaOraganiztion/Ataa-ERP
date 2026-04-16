using Application.Abstractions.Messaging;
using Application.Abstractions.Repositories;
using Application.Abstractions.Services;
using AutoMapper;
using Domain.Email;
using SharedKernel;

namespace Application.Features.CRM.Lead.Commands.Add;

public class AddLeadCommandHandler(IMapper mapper, IRepository<Domain.Models.CRM.Lead.Lead> repository, IEmailService emailService) : ICommandHandler<AddLeadCommand, Ulid>
{
    public async Task<Result<Ulid>> Handle(AddLeadCommand request, CancellationToken cancellationToken)
    {
        var lead = mapper.Map<Domain.Models.CRM.Lead.Lead>(request);
        await repository.AddAsync(lead, cancellationToken);

        return Result.Success(lead.Id);
    }
}