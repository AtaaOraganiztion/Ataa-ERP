using Application.Abstractions.Messaging;
using Domain.Entities.Enums;

namespace Application.Features.Sector.Commands.Add;

public record AddSectorCommand( 
    string Name,
    string Description,
    Ulid? ParentId,
    Ulid? ManagerUserId
    
    ) : ICommand<Ulid>;