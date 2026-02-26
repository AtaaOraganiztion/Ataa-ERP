using Application.Abstractions.Messaging;

namespace Application.Features.Identities.Users.UpdateUserRoles;

public record UpdateUserRolesCommand(Ulid UserId, List<Ulid> RolesIds) : ICommand;
