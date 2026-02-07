namespace Application.Abstractions.Authentication;

public interface IUserContext
{
    Ulid GetUserId();

    bool CanBypassOwnershipCheck();
    
    bool CanBypassDeletedCheck();
}
