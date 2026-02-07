namespace SharedKernel;

public class BusinessRuleValidationException(IBusinessRule brokenRule) : Exception(brokenRule.MessageKey)
{
    public IBusinessRule BrokenRule { get; } = brokenRule;

    public string Details { get; } = brokenRule.MessageKey;

    public override string ToString()
    {
        return $"{BrokenRule.GetType().FullName}: {BrokenRule.MessageKey}";
    }
}
