using Application.Abstractions.Authentication;
using Application.Abstractions.Messaging;
using Application.Abstractions.Repositories;
using Application.Features.CRM.Activity.Commands.Add;
using AutoMapper;
using SharedKernel;

public class AddActivityCommandHandler(
    IMapper mapper,
    IRepository<Domain.Models.CRM.Activity.Activity> repository,
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
        return Result.Success(activity.Id);
    }
} 