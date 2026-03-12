using Application.Abstractions.Messaging;
using Application.Abstractions.Repositories;
using Application.Abstractions.Services;
using AutoMapper;
using Domain.Email;
using SharedKernel;

namespace Application.Features.Sector.Commands.Add;

public class AddSectorCommandHandler(IMapper mapper, IRepository<Domain.Models.Sector.Sector> repository) : ICommandHandler<AddSectorCommand,Ulid>
{
    public async Task<Result<Ulid>> Handle(AddSectorCommand request, CancellationToken cancellationToken)
    {
        var sector = mapper.Map<Domain.Models.Sector.Sector>(request);

        await repository.AddAsync(sector, cancellationToken);
        
        return Result.Success(sector.Id);
    }
}