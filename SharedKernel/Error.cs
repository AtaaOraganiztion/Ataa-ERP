namespace SharedKernel;

public record Error
{
    public static readonly Error None = new(string.Empty, ErrorType.Failure);

    public static readonly Error NullValue = new(
        "General.Null",
        ErrorType.Failure);

    public Error(string code, ErrorType type)
    {
        Code = code;
        Type = type;
    }

    public string Code { get; }


    public ErrorType Type { get; }

    public static Error Failure(string code) =>
        new(code, ErrorType.Failure);

    public static Error NotFound(string code) =>
        new(code, ErrorType.NotFound);

    public static Error Problem(string code) =>
        new(code, ErrorType.Problem);

    public static Error Conflict(string code) =>
        new(code, ErrorType.Conflict);

    public static Error Invalid(string code) =>
        new(code, ErrorType.Validation);

    public static Error Unauthorized(string code) =>
        new(code, ErrorType.Unauthorized);
}
