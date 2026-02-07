
namespace SharedKernel;

public record DomainEventBase : IDomainEvent
{
    public Ulid Id { get; } = Ulid.NewUlid();

    public DateTime OccurredOn { get; } = SystemClock.Now;
}
