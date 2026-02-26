using Domain.Entities;
using SharedKernel;

namespace Domain.Identities.Event;

public record UserRegisteredDomainEvent(User User) : DomainEventBase;
