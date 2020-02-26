using MediatR;
using Pedidos.Application.Pagination;
using Pedidos.Domain.Pagination;
using Pedidos.Domain.Produtos;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Pedidos.Application.Produtos.Queries.GetListaProdutos
{
    public class GetListaProdutosQueryHandler : IRequestHandler<GetListaProdutosQuery, PaginatedResult<ProdutoViewModel>>
    {
        private readonly IProdutoRepository _produtoRepository;

        public GetListaProdutosQueryHandler(IProdutoRepository produtoRepository)
        {
            _produtoRepository = produtoRepository;
        }

        public async Task<PaginatedResult<ProdutoViewModel>> Handle(GetListaProdutosQuery request, CancellationToken cancellationToken)
        {
            var paginatedResult = await _produtoRepository
                .FindAllPaginatedAsync(new PaginationOptions(request.PageIndex, request.PageSize, request.Sort));

            PaginatedResult<ProdutoViewModel> result = new PaginatedResult<ProdutoViewModel>(
                paginatedResult.Data.Select(x => new ProdutoViewModel
                {
                    Id = x.Id,
                    Descricao = x.Descricao,
                    Valor = x.Valor
                }),
                paginatedResult.DataLenght,
                paginatedResult.PageIndex,
                paginatedResult.PageSize,
                paginatedResult.TotalPages);

            return result;

        }
    }
}