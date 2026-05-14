using Application.Abstractions.Authentication;
using Application.Abstractions.Messaging;
using Application.Abstractions.Repositories;
using Application.Features.CRM.GlobalActivity.Commands.Update;
using Application.Features.CRM.GlobalActivity.Specifications;
using Domain.Models.CRM.GlobalActivity;
using AutoMapper;
using Domain.Routing.BaseRouter;
using SharedKernel;

namespace Application.Features.CRM.GlobalActivity.Commands.Update;

public class UpdateGlobalActivityCommandHandler(
    IMapper mapper,
    IRepository<Domain.Models.CRM.GlobalActivity.GlobalActivity> repository,
    IRepository<Domain.Models.Notifications.Notification> notificationRepository,
    IFileStorageService fileStorage,
    IUserContext userContext)
    : ICommandHandler<UpdateGlobalActivityCommand, Ulid>
{
    public async Task<Result<Ulid>> Handle(UpdateGlobalActivityCommand request, CancellationToken cancellationToken)
    {
        var userId = userContext.GetUserId();
        var activity = await repository.FirstOrDefaultAsync(
            new GlobalActivityByIdSpec(request.Id), cancellationToken);

        if (activity is null)
            return Result.Failure<Ulid>(Error.NotFound(GlobalActivityMessageKeys.GlobalActivityNotFound));

        mapper.Map(request.Request, activity);

        if (request.Request.DeletedFileIds is { Count: > 0 })
        {
            var filesToRemove = activity.Files
                .Where(f => request.Request.DeletedFileIds.Contains(f.Id))
                .ToList();

            foreach (var file in filesToRemove)
            {
                fileStorage.Delete(file.StoragePath);
                activity.Files.Remove(file);
            }
        }

        var addedFiles = new List<Domain.Models.CRM.GlobalActivity.GlobalActivity.File>();

        if (request.Request.Files is not null)
        {
            foreach (var formFile in request.Request.Files)
            {
                var storagePath = await fileStorage.SaveAsync(formFile, cancellationToken);

                var file = new Domain.Models.CRM.GlobalActivity.GlobalActivity.File
                {
                    GlobalActivity = activity,
                    FileName = formFile.FileName,
                    StoragePath = storagePath,
                    ContentType = formFile.ContentType,
                    FileSizeInBytes = formFile.Length,
                    UploadedAtUtc = DateTime.UtcNow,
                    CreatedByUserId = userId
                };

                activity.Files.Add(file);
                addedFiles.Add(file);
            }
        }

        await repository.UpdateAsync(activity, cancellationToken);

        if (addedFiles.Any())
        {
            await notificationRepository.AddAsync(new Domain.Models.Notifications.Notification
            {
                UserId = null,
                CreatedByUserId = userId,
                Type = "GlobalActivityFileUploaded",
                Title = "New file added to a global activity",
                Message = activity.Subject,
                EntityType = nameof(Domain.Models.CRM.GlobalActivity.GlobalActivity),
                EntityId = activity.Id,
                Link = "/" + Router.GlobalActivity.GetById.Replace("{id}", activity.Id.ToString()),
                IsRead = false,
                CreatedAtUtc = DateTime.UtcNow
            }, cancellationToken);
        }

        return Result.Success(activity.Id);
    }
}
