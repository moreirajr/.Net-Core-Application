using MediatR;
using Pedidos.Application.Pagination;
using Pedidos.Domain.Produtos;

namespace Pedidos.Application.Produtos.Queries.GetListaProdutos
{
    public class GetListaProdutosQuery : IRequest<PaginatedResult<ProdutoViewModel>>
    {
        public int PageIndex { get; }
        public int PageSize { get; }

        public string Sort { get; }

        public GetListaProdutosQuery(PaginationQueryParameters paginationQueryParams)
        {
            PageIndex = PaginationParametersValidation.ValidatedPageIndex(paginationQueryParams.pageIndex);
            PageSize = PaginationParametersValidation.ValidatedPageSize(paginationQueryParams.pageSize);
            Sort = PaginationParametersValidation.ValidatedSortProperty(paginationQueryParams.sort, typeof(Produto));
        }
    }
}