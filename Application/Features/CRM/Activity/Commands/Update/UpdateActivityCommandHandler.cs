using Application.Abstractions.Authentication;
using Application.Abstractions.Messaging;
using Application.Abstractions.Repositories;
using Application.Features.CRM.Activity.Commands.Update;
using AutoMapper;
using Domain.Models.CRM.Activity;
using Domain.Routing.BaseRouter;
using SharedKernel;
public class UpdateActivityCommandHandler(
    IMapper mapper,
    IRepository<Domain.Models.CRM.Activity.Activity> repository,
    IRepository<Domain.Models.Notifications.Notification> notificationRepository,
    IFileStorageService fileStorage,
    IUserContext userContext)
    : ICommandHandler<UpdateActivityCommand, Ulid>
{
    public async Task<Result<Ulid>> Handle(UpdateActivityCommand request, CancellationToken cancellationToken)
    {
        var userId = userContext.GetUserId();
        var activity = await repository.FirstOrDefaultAsync(
            new ActivityByIdSpec(request.Id), cancellationToken);

        if (activity is null)
            return Result.Failure<Ulid>(Error.NotFound(ActivityMessageKeys.ActivityNotFound));

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

        var addedFiles = new List<Domain.Models.CRM.Activity.Activity.File>();

        if (request.Request.Files is not null)
        {
            // add new files
            foreach (var formFile in request.Request.Files)
            {
                var storagePath = await fileStorage.SaveAsync(formFile, cancellationToken);

                var file = new Domain.Models.CRM.Activity.Activity.File
                {
                    Activity = activity,
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
            var recipients = new HashSet<Ulid>();

            if (activity.CreatedByUserId.HasValue && activity.CreatedByUserId.Value != userId)
                recipients.Add(activity.CreatedByUserId.Value);

            if (activity.AssignedToUserId.HasValue && activity.AssignedToUserId.Value != userId)
                recipients.Add(activity.AssignedToUserId.Value);

            foreach (var recipient in recipients)
            {
                await notificationRepository.AddAsync(new Domain.Models.Notifications.Notification
                {
                    UserId = recipient,
                    CreatedByUserId = userId,
                    Type = "ActivityFileUploaded",
                    Title = "New file added to activity",
                    Message = activity.Subject,
                    EntityType = nameof(Domain.Models.CRM.Activity.Activity),
                    EntityId = activity.Id,
                    Link = "/" + Router.Activity.GetById.Replace("{id}", activity.Id.ToString()),
                    IsRead = false,
                    CreatedAtUtc = DateTime.UtcNow
                }, cancellationToken);
            }
        }

        return Result.Success(activity.Id);
    }
}