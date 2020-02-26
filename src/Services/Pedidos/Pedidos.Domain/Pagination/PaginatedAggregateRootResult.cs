using System;
using System.Collections.Generic;

namespace Pedidos.Domain.SeedWork
{
    public class PaginatedAggregateRootResult<TViewModel> where TViewModel : IAggregateRoot
    {
        private const int MinimumPageSize = 20;
        private const int MinimumPageIndex = 1;

        public int PageIndex { get; }
        public int PageSize { get; }
        public int TotalPages { get; }

        public IEnumerable<TViewModel> Data { get; }
        public long DataLenght { get; }

        public PaginatedAggregateRootResult(IEnumerable<TViewModel> data, long count, int pageIndex = MinimumPageIndex, int pageSize = MinimumPageSize)
        {
            PageIndex = pageIndex < MinimumPageIndex ? MinimumPageIndex : pageIndex;
            PageSize = pageSize < MinimumPageSize ? MinimumPageSize : pageSize;
            Data = data;
            DataLenght = count;
            TotalPages = (int)Math.Ceiling(decimal.Divide(count, pageSize));
        }
    }
}