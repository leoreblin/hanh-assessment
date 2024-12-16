namespace Shared.Pagination;

public static class PagedListExtensions
{
    public static async Task<PagedList<TEntity>> ToPagedListAsync<TEntity>(
        this IQueryable<TEntity> source,
        PaginateQuery paginate,
        Func<TEntity, bool>? whereClause = null,
        CancellationToken token = default)
    {
        if (whereClause is not null)
        {
            source = source.Where(whereClause).AsQueryable();
        }

        var totalCount = await source.ToAsyncEnumerable().CountAsync(token);
        if (totalCount > 0)
        {
            var items = await source.ToAsyncEnumerable()
                .Skip((paginate.Page - 1) * paginate.Size)
                .Take(paginate.Size)
                .ToListAsync(token);

            return new PagedList<TEntity>(items, totalCount, paginate.Page, paginate.Size);
        }

        return new PagedList<TEntity>([], 0, 0, 0);
    }
}
