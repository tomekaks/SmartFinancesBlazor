namespace SmartFinancesBlazorUI.Models
{
    public class PaginatedList<T>
    {
        public PaginatedList(List<T>items, int pageNumber, int pageSize, int totalPages, int totalCount)
        {
            Items = items;
            PageNumber = pageNumber;
            PageSize = pageSize;
            TotalPages = totalPages;
            TotalCount = totalCount;
        }

        public List<T> Items { get; set; }
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public int TotalPages { get; set; }
        public int TotalCount { get; set; }
    }
}
