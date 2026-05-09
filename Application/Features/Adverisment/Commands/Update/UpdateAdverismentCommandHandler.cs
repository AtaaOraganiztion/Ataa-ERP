using Application.Abstractions.Authentication;
using Application.Abstractions.Messaging;
using Application.Abstractions.Repositories;
using AutoMapper;
using Domain.Models.Adverisment;
using SharedKernel;
using Application.Features.Adverisment.Specifications;

namespace Application.Features.Adverisment.Commands.Update;

public class UpdateAdverismentCommandHandler(
    IMapper mapper,
    IRepository<Domain.Models.Adverisment.Adverisment> repository,
    IFileStorageService fileStorage,
    IUserContext userContext)
    : ICommandHandler<UpdateAdverismentCommand, Ulid>
{
    public async Task<Result<Ulid>> Handle(UpdateAdverismentCommand request, CancellationToken cancellationToken)
    {
        var userId = userContext.GetUserId();
        var adverisment = await repository.FirstOrDefaultAsync(
            new AdverismentByIdSpec(request.Id), cancellationToken);

        if (adverisment is null)
            return Result.Failure<Ulid>(Error.NotFound(AdverismentMessageKeys.AdverismentNotFound));

        mapper.Map(request.Request, adverisment);

        if (request.Request.DeletedFileIds is { Count: > 0 })
        {
            var filesToRemove = adverisment.Files
                .Where(f => request.Request.DeletedFileIds.Contains(f.Id))
                .ToList();

            foreach (var file in filesToRemove)
            {
                fileStorage.Delete(file.StoragePath);
                adverisment.Files.Remove(file);
            }
        }

        if (request.Request.Files is not null)
        {
            foreach (var formFile in request.Request.Files)
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

        await repository.UpdateAsync(adverisment, cancellationToken);
        return Result.Success(adverisment.Id);
    }
}