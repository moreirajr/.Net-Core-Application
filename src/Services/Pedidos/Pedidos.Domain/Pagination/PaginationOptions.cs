
namespace Pedidos.Domain.Pagination
{
    public class PaginationOptions
    {
        public int PageIndex { get; }
        public int PageSize { get; }

        public string SortingProperty { get; }

        public PaginationOptions(int pageIndex, int pageSize, string sortingProperty)
        {
            PageIndex = pageIndex;
            PageSize = pageSize;
            SortingProperty = sortingProperty;
        }

    }
}