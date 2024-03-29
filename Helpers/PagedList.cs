using Microsoft.EntityFrameworkCore;

namespace OpenSeaWebApi.Helpers;

public class PagedList<T> : List<T>
{
    public PagedList(IEnumerable<T> items, int count, int pageNumber, int pageSize)
    {
        CurrentPage = pageNumber;
        TotalPages = (int)Math.Ceiling(count / (double)pageSize);
        PageSize = pageSize;
        TotalCount = count;
        AddRange(items);
    }

    public PagedList(int currentPage, int totalPages, int pageSize, int totalCount)
    {
        this.CurrentPage = currentPage;
        this.TotalPages = totalPages;
        this.PageSize = pageSize;
        this.TotalCount = totalCount;

    }
    public int CurrentPage { get; set; }
    public int TotalPages { get; set; }
    public int PageSize { get; set; }
    public int TotalCount { get; set; }

    public static async Task<PagedList<T>> CreateAsync(IQueryable<T> source, int pageNumber, int pageSize, List<FilterOptions>? FilterOptions2=null)
    {
        if (FilterOptions2 != null)
        {
            foreach (var x in FilterOptions2)
            {
                source = source.Where(FilterExpression.BuildPredicate<T>(x.field, x.operators, x.value));
            }
        }
        var count = await source.CountAsync();
        var items = await source.Skip((pageNumber - 1) * pageSize).Take(pageSize).ToListAsync();
        return new PagedList<T>(items, count, pageNumber, pageSize);
    }
}