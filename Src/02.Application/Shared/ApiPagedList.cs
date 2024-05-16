namespace Shared
{

    public class ApiPagedList<T>
    {
        public int PageNumber { get; }

        public int PageSize { get; }

        public int TotalItems { get; }

        public int TotalPages { get; }

        public bool HasPreviousPage => PageNumber > 1;

        public bool HasNextPage => PageNumber < TotalPages;

        public IEnumerable<T> Items { get; }

        public ApiPagedList(
            int pageNumber,
            int pageSize,
            IQueryable<T> items)
        {
            PageNumber = pageNumber;
            PageSize = pageSize;
            TotalItems = items.Count();
            TotalPages = (TotalItems + PageSize - 1) / PageSize;
            Items = items.Skip((pageNumber - 1) * pageSize).Take(pageSize);
        }
    }
}
