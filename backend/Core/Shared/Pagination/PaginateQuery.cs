namespace Shared.Pagination;

public class PaginateQuery
{
    public PaginateQuery()
    {
        Size = 10;
        Page = 1;
    }

    public int Size { get; set; }

    public int Page { get; set; }
}
