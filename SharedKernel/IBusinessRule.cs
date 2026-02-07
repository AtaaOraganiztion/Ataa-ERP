namespace SharedKernel;

public interface IBusinessRule
{
    bool IsBroken();

    string MessageKey { get; }
}
