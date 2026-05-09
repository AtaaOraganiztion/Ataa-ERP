using Application.Abstractions.Authentication;
using Application.Abstractions.Messaging;
using Application.Abstractions.Repositories;
using Application.Features.CRM.Activity.Commands.Update;
using AutoMapper;
using Domain.Models.CRM.Activity;
using SharedKernel;
public class UpdateActivityCommandHandler(
    IMapper mapper,
    IRepository<Domain.Models.CRM.Activity.Activity> repository,
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

        if (request.Request.Files is not null)
        {
            // add new files
            foreach (var formFile in request.Request.Files)
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

        await repository.UpdateAsync(activity, cancellationToken);
        return Result.Success(activity.Id);
    }
}