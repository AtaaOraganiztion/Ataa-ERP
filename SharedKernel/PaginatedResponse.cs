namespace SharedKernel;

public class PaginatedResponse<TResponse>
{
    public int PageIndex { get; init; }
    public int PageSize { get; init; }
    public int TotalCount { get; init; }
    public int TotalPages { get; init; }
    public bool HasPreviousPage { get; init; }
    public bool HasNextPage { get; init; }
    public List<TResponse> Data { get; init; }

    public PaginatedResponse(List<TResponse> data, int totalCount, int pageIndex, int pageSize)
    {
        Data = data;
        PageIndex = pageIndex;
        PageSize = pageSize;
        TotalCount = totalCount;
        TotalPages = (int)Math.Ceiling(totalCount / (double)pageSize);
        HasPreviousPage = pageIndex > 1;
        HasNextPage = pageIndex < TotalPages;
    }
}
