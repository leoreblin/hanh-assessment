namespace Shared.Pagination;

public class PagedList<T>(
    IEnumerable<T> items,
    int totalCount,
    int pageNumber,
    int pageSize)
{
    public int PageNumber { get; } = pageNumber;

    public int TotalPages { get; } = totalCount == 0 ? 0 : (int)Math.Ceiling(totalCount / (double)pageSize);

    public int TotalCount { get; } = totalCount;

    public int PageSize { get; } = pageSize;

    public IList<T> Items { get; } = new List<T>(items);

    public bool IsFirstPage => PageNumber == 1;

    public bool IsLastPage => PageNumber == TotalPages;

    public int Count => Items.Count;
}
