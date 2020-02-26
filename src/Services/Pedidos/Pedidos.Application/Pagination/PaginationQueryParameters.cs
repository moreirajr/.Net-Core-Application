
namespace Pedidos.Application.Pagination
{
    public class PaginationQueryParameters
    {
        public int pageIndex { get; set; }
        public int pageSize { get; set; }
        public string sort { get; set; }
    }
}