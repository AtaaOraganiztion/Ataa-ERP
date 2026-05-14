using Application.Abstractions.Authentication;
using Application.Abstractions.Messaging;
using Application.Abstractions.Repositories;
using AutoMapper;
using Domain.Routing.BaseRouter;
using Domain.Models.Adverisment;
using SharedKernel;
using Application.Features.Adverisment.Specifications;

namespace Application.Features.Adverisment.Commands.Update;

public class UpdateAdverismentCommandHandler(
    IMapper mapper,
    IRepository<Domain.Models.Adverisment.Adverisment> repository,
    IRepository<Domain.Models.Notifications.Notification> notificationRepository,
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

        var addedFiles = new List<Domain.Models.Adverisment.Adverisment.AdverismentFile>();

        if (request.Request.Files is not null)
        {
            foreach (var formFile in request.Request.Files)
            {
                var storagePath = await fileStorage.SaveAsync(formFile, cancellationToken);

                var file = new Domain.Models.Adverisment.Adverisment.AdverismentFile
                {
                    AdverismentId = adverisment.Id,
                    Adverisment = adverisment,
                    FileName = formFile.FileName,
                    StoragePath = storagePath,
                    ContentType = formFile.ContentType,
                    FileSizeInBytes = formFile.Length,
                    UploadedAtUtc = DateTime.UtcNow,
                    CreatedByUserId = userId
                };

                adverisment.Files.Add(file);
                addedFiles.Add(file);
            }
        }

        await repository.UpdateAsync(adverisment, cancellationToken);

        if (addedFiles.Any() && adverisment.CreatedByUserId.HasValue && adverisment.CreatedByUserId.Value != userId)
        {
            await notificationRepository.AddAsync(new Domain.Models.Notifications.Notification
            {
                UserId = adverisment.CreatedByUserId,
                CreatedByUserId = userId,
                Type = "AdverismentFileUploaded",
                Title = "New file added to advertisement",
                Message = adverisment.Title,
                EntityType = nameof(Domain.Models.Adverisment.Adverisment),
                EntityId = adverisment.Id,
                Link = "/" + Router.Adverisment.GetById.Replace("{id}", adverisment.Id.ToString()),
                IsRead = false,
                CreatedAtUtc = DateTime.UtcNow
            }, cancellationToken);
        }

        return Result.Success(adverisment.Id);
    }
}