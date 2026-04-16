using Application.Abstractions.Messaging;
using Application.Abstractions.Repositories;
using Application.Features.CRM.Activity.Commands.Update;
using AutoMapper;
using Domain.Models.CRM.Activity;
using SharedKernel;
public class UpdateActivityCommandHandler(
    IMapper mapper,
    IRepository<Domain.Models.CRM.Activity.Activity> repository,
    IFileStorageService fileStorage)
    : ICommandHandler<UpdateActivityCommand, Ulid>
{
    public async Task<Result<Ulid>> Handle(UpdateActivityCommand request, CancellationToken cancellationToken)
    {
        var activity = await repository.FirstOrDefaultAsync(
            new ActivityByIdSpec(request.Id), cancellationToken);

        if (activity is null)
            return Result.Failure<Ulid>(Error.NotFound(ActivityMessageKeys.ActivityNotFound));

        mapper.Map(request.Request, activity);

        if (request.Request.Files is not null)
        {
            // delete old files
            foreach (var existing in activity.Files)
            {
                fileStorage.Delete(existing.StoragePath);
            }

            activity.Files.Clear();

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
                    UploadedAtUtc = DateTime.UtcNow
                });
            }
        }

        await repository.UpdateAsync(activity, cancellationToken);
        return Result.Success(activity.Id);
    }
}