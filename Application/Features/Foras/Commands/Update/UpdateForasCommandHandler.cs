using Application.Abstractions.Authentication;
using Application.Abstractions.Messaging;
using Application.Abstractions.Repositories;
using AutoMapper;
using Domain.Models.Foras;
using SharedKernel;
using Application.Features.Foras.Specifications;

namespace Application.Features.Foras.Commands.Update;

public class UpdateForasCommandHandler(
    IMapper mapper,
    IRepository<Domain.Models.Foras.Foras> repository,
    IFileStorageService fileStorage,
    IUserContext userContext)
    : ICommandHandler<UpdateForasCommand, Ulid>
{
    public async Task<Result<Ulid>> Handle(UpdateForasCommand request, CancellationToken cancellationToken)
    {
        var userId = userContext.GetUserId();
        var foras = await repository.FirstOrDefaultAsync(
            new ForasByIdSpec(request.Id), cancellationToken);

        if (foras is null)
            return Result.Failure<Ulid>(Error.NotFound(ForasMessageKeys.ForasNotFound));

        mapper.Map(request.Request, foras);

        if (request.Request.DeletedFileIds is { Count: > 0 })
        {
            var filesToRemove = foras.Files
                .Where(f => request.Request.DeletedFileIds.Contains(f.Id))
                .ToList();

            foreach (var file in filesToRemove)
            {
                fileStorage.Delete(file.StoragePath);
                foras.Files.Remove(file);
            }
        }

        if (request.Request.Files is not null)
        {
            foreach (var formFile in request.Request.Files)
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

        await repository.UpdateAsync(foras, cancellationToken);
        return Result.Success(foras.Id);
    }
}
