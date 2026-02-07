namespace SharedKernel;

public record BaseFilter
{
    public int PageIndex { get; init; } = 1;


    private readonly int _pageSize = 10;

    public int PageSize
    {
        get => _pageSize;
        init => _pageSize = value switch
        {
            <= 5 => 5,
            >= 30 => 30,
            _ => value
        };
    }
}
