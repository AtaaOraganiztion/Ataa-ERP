namespace SharedKernel;

public interface IHasKey<TType>
{
    TType Id { get; set; }
}
