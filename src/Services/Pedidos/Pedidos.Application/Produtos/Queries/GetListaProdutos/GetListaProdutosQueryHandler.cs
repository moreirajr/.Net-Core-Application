using MediatR;
using Pedidos.Domain.Produtos;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Pedidos.Application.Produtos.Queries.GetListaProdutos
{
    public class GetListaProdutosQueryHandler : IRequestHandler<GetListaProdutosQuery, IList<ProdutoViewModel>>
    {
        private readonly IProdutoRepository _produtoRepository;

        public GetListaProdutosQueryHandler(IProdutoRepository produtoRepository)
        {
            _produtoRepository = produtoRepository;
        }

        public async Task<IList<ProdutoViewModel>> Handle(GetListaProdutosQuery request, CancellationToken cancellationToken)
        {
            var produtos = await _produtoRepository.FindAllAsync();

            return produtos.Select(x => new ProdutoViewModel
            {
                Id = x.Id,
                Descricao = x.Descricao,
                Valor = x.Valor
            }).ToList();
        }
    }
}