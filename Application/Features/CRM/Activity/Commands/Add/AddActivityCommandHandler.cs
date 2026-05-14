using Application.Abstractions.Authentication;
using Application.Abstractions.Messaging;
using Application.Abstractions.Repositories;
using Application.Features.CRM.Activity.Commands.Add;
using AutoMapper;
using Domain.Routing.BaseRouter;
using SharedKernel;

public class AddActivityCommandHandler(
    IMapper mapper,
    IRepository<Domain.Models.CRM.Activity.Activity> repository,
    IRepository<Domain.Models.Notifications.Notification> notificationRepository,
    IFileStorageService fileStorage,
    IUserContext userContext)
    : ICommandHandler<AddActivityCommand, Ulid>
{
    public async Task<Result<Ulid>> Handle(AddActivityCommand request, CancellationToken cancellationToken)
    {
        var userId = userContext.GetUserId();
        var activity = mapper.Map<Domain.Models.CRM.Activity.Activity>(request);

        if (request.Files is { Count: > 0 })
        {
            foreach (var formFile in request.Files)
            {
                var storagePath = await fileStorage.SaveAsync(formFile, cancellationToken);
                activity.Files.Add(new Domain.Models.CRM.Activity.Activity.File
                {
                    Activity = activity,
                    FileName = formFile.FileName,
                    StoragePath = storagePath,
                    ContentType = formFile.ContentType,
                    FileSizeInBytes = formFile.Length,
                    UploadedAtUtc = DateTime.UtcNow,
                    CreatedByUserId = userId
                });
            }
        }

        await repository.AddAsync(activity, cancellationToken);

        if (activity.AssignedToUserId.HasValue && activity.AssignedToUserId.Value != userId)
        {
            await notificationRepository.AddAsync(new Domain.Models.Notifications.Notification
            {
                UserId = activity.AssignedToUserId.Value,
                CreatedByUserId = userId,
                Type = "ActivityCreated",
                Title = "New activity assigned",
                Message = activity.Subject,
                EntityType = nameof(Domain.Models.CRM.Activity.Activity),
                EntityId = activity.Id,
                Link = "/" + Router.Activity.GetById.Replace("{id}", activity.Id.ToString()),
                IsRead = false,
                CreatedAtUtc = DateTime.UtcNow
            }, cancellationToken);
        }

        return Result.Success(activity.Id);
    }
} 