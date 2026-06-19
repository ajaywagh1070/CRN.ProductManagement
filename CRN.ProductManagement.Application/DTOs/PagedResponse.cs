namespace CRN.ProductManagement.Application.DTOs;

public class PagedResponse<T>
{
    public int Page { get; set; }

    public int PageSize { get; set; }

    public int TotalRecords { get; set; }

    public IEnumerable<T> Data { get; set; }
        = Enumerable.Empty<T>();
}