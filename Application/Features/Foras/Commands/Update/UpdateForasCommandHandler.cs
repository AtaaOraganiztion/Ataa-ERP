using Application.Abstractions.Authentication;
using Application.Abstractions.Messaging;
using Application.Abstractions.Repositories;
using AutoMapper;
using Domain.Routing.BaseRouter;
using Domain.Models.Foras;
using SharedKernel;
using Application.Features.Foras.Specifications;

namespace Application.Features.Foras.Commands.Update;

public class UpdateForasCommandHandler(
    IMapper mapper,
    IRepository<Domain.Models.Foras.Foras> repository,
    IRepository<Domain.Models.Notifications.Notification> notificationRepository,
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

        var addedFiles = new List<Domain.Models.Foras.Foras.ForasFile>();

        if (request.Request.Files is not null)
        {
            foreach (var formFile in request.Request.Files)
            {
                var storagePath = await fileStorage.SaveAsync(formFile, cancellationToken);

                var file = new Domain.Models.Foras.Foras.ForasFile
                {
                    ForasId = foras.Id,
                    Foras = foras,
                    FileName = formFile.FileName,
                    StoragePath = storagePath,
                    ContentType = formFile.ContentType,
                    FileSizeInBytes = formFile.Length,
                    UploadedAtUtc = DateTime.UtcNow,
                    CreatedByUserId = userId
                };

                foras.Files.Add(file);
                addedFiles.Add(file);
            }
        }

        await repository.UpdateAsync(foras, cancellationToken);

        if (addedFiles.Any() && foras.CreatedByUserId.HasValue && foras.CreatedByUserId.Value != userId)
        {
            await notificationRepository.AddAsync(new Domain.Models.Notifications.Notification
            {
                UserId = foras.CreatedByUserId,
                CreatedByUserId = userId,
                Type = "ForasFileUploaded",
                Title = "New file added to Foras",
                Message = foras.Title,
                EntityType = nameof(Domain.Models.Foras.Foras),
                EntityId = foras.Id,
                Link = "/" + Router.Foras.GetById.Replace("{id}", foras.Id.ToString()),
                IsRead = false,
                CreatedAtUtc = DateTime.UtcNow
            }, cancellationToken);
        }

        return Result.Success(foras.Id);
    }
}
