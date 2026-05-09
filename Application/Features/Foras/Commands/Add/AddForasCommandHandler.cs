using Application.Abstractions.Authentication;
using Application.Abstractions.Messaging;
using Application.Abstractions.Repositories;
using AutoMapper;
using Domain.Models.Foras;
using SharedKernel;

namespace Application.Features.Foras.Commands.Add;

public class AddForasCommandHandler(
    IMapper mapper,
    IRepository<Domain.Models.Foras.Foras> repository,
    IFileStorageService fileStorage,
    IUserContext userContext)
    : ICommandHandler<AddForasCommand, Ulid>
{
    public async Task<Result<Ulid>> Handle(AddForasCommand request, CancellationToken cancellationToken)
    {
        var userId = userContext.GetUserId();
        var foras = mapper.Map<Domain.Models.Foras.Foras>(request);
        foras.CreatedByUserId ??= userId;

        if (request.Files is { Count: > 0 })
        {
            foreach (var formFile in request.Files)
            {
                var storagePath = await fileStorage.SaveAsync(formFile, cancellationToken);
                foras.Files.Add(new Domain.Models.Foras.Foras.ForasFile
                {
                    ForasId = foras.Id,
                    Foras = foras,
                    FileName = formFile.FileName,
                    StoragePath = storagePath,
                    ContentType = formFile.ContentType,
                    FileSizeInBytes = formFile.Length,
                    UploadedAtUtc = DateTime.UtcNow,
                    CreatedByUserId = userId
                });
            }
        }

        await repository.AddAsync(foras, cancellationToken);
        return Result.Success(foras.Id);
    }
}
