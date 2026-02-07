using MediatR;

namespace SharedKernel;

public interface IDomainEvent : INotification
{
    Ulid Id { get; }

    DateTime OccurredOn { get; }
}
