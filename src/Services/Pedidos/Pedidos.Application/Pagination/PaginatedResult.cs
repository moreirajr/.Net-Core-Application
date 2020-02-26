using System.Collections.Generic;


namespace Pedidos.Application.Pagination
{
    public class PaginatedResult<TViewModel> where TViewModel : IViewModel
    {
        public int PageIndex { get; }
        public int PageSize { get; }
        public int TotalPages { get; }
        public IEnumerable<TViewModel> Data { get; }
        public long DataLenght { get; }

        public PaginatedResult(IEnumerable<TViewModel> data, long count, int pageIndex, int pageSize, int totalPages)
        {
            PageIndex = pageIndex;
            PageSize = pageSize;
            Data = data;
            DataLenght = count;
            TotalPages = totalPages;
        }
    }
}