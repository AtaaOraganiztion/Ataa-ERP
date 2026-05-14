using Application.Abstractions.Authentication;
using Application.Abstractions.Messaging;
using Application.Abstractions.Repositories;
using Application.Features.CRM.GlobalActivity.Commands.Add;
using Domain.Models.CRM.GlobalActivity;
using AutoMapper;
using Domain.Routing.BaseRouter;
using SharedKernel;

namespace Application.Features.CRM.GlobalActivity.Commands.Add;

public class AddGlobalActivityCommandHandler(
    IMapper mapper,
    IRepository<Domain.Models.CRM.GlobalActivity.GlobalActivity> repository,
    IRepository<Domain.Models.Notifications.Notification> notificationRepository,
    IFileStorageService fileStorage,
    IUserContext userContext)
    : ICommandHandler<AddGlobalActivityCommand, Ulid>
{
    public async Task<Result<Ulid>> Handle(AddGlobalActivityCommand request, CancellationToken cancellationToken)
    {
        var userId = userContext.GetUserId();
        var activity = mapper.Map<Domain.Models.CRM.GlobalActivity.GlobalActivity>(request);
        activity.CreatedByUserId = userId;

        if (request.Files is { Count: > 0 })
        {
            foreach (var formFile in request.Files)
            {
                var storagePath = await fileStorage.SaveAsync(formFile, cancellationToken);
                activity.Files.Add(new Domain.Models.CRM.GlobalActivity.GlobalActivity.File
                {
                    GlobalActivity = activity,
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

        await notificationRepository.AddAsync(new Domain.Models.Notifications.Notification
        {
            UserId = null,
            CreatedByUserId = userId,
            Type = "GlobalActivityCreated",
            Title = "New global activity created",
            Message = activity.Subject,
            EntityType = nameof(Domain.Models.CRM.GlobalActivity.GlobalActivity),
            EntityId = activity.Id,
            Link = "/" + Router.GlobalActivity.GetById.Replace("{id}", activity.Id.ToString()),
            IsRead = false,
            CreatedAtUtc = DateTime.UtcNow
        }, cancellationToken);

        return Result.Success(activity.Id);
    }
}
