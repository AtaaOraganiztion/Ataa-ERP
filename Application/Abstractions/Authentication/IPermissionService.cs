namespace Application.Abstractions.Authentication;

public interface IPermissionService
{
    Task<bool> HasPermissionAsync(Ulid userId, string[] permissions);
}
