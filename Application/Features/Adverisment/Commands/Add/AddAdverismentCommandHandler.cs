using Application.Abstractions.Authentication;
using Application.Abstractions.Messaging;
using Application.Abstractions.Repositories;
using AutoMapper;
using Domain.Models.Adverisment;
using SharedKernel;

namespace Application.Features.Adverisment.Commands.Add;

public class AddAdverismentCommandHandler(
    IMapper mapper,
    IRepository<Domain.Models.Adverisment.Adverisment> repository,
    IFileStorageService fileStorage,
    IUserContext userContext)
    : ICommandHandler<AddAdverismentCommand, Ulid>
{
    public async Task<Result<Ulid>> Handle(AddAdverismentCommand request, CancellationToken cancellationToken)
    {
        var userId = userContext.GetUserId();
        var adverisment = mapper.Map<Domain.Models.Adverisment.Adverisment>(request);
        adverisment.CreatedByUserId ??= userId;

        if (request.Files is { Count: > 0 })
        {
            foreach (var formFile in request.Files)
            {
                var storagePath = await fileStorage.SaveAsync(formFile, cancellationToken);
                adverisment.Files.Add(new Domain.Models.Adverisment.Adverisment.AdverismentFile
                {
                    AdverismentId = adverisment.Id,
                    Adverisment = adverisment,
                    FileName = formFile.FileName,
                    StoragePath = storagePath,
                    ContentType = formFile.ContentType,
                    FileSizeInBytes = formFile.Length,
                    UploadedAtUtc = DateTime.UtcNow,
                    CreatedByUserId = userId
                });
            }
        }

        await repository.AddAsync(adverisment, cancellationToken);
        return Result.Success(adverisment.Id);
    }
}