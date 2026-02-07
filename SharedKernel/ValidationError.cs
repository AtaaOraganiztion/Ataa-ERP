namespace SharedKernel;

public sealed record ValidationError(Error[] Errors) : Error("Validation.General", ErrorType.Validation);
