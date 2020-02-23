using MediatR;
using Pedidos.Domain.Produtos;
using System.Threading;
using System.Threading.Tasks;

namespace Pedidos.Application.Produtos.Queries.GetDetalhesProduto
{
    public class GetDetalhesProdutoQueryHandler : IRequestHandler<GetDetalhesProdutoQuery, ProdutoViewModel>
    {
        private readonly IProdutoRepository _produtoRepository;

        public GetDetalhesProdutoQueryHandler(IProdutoRepository produtoRepository)
        {
            _produtoRepository = produtoRepository;
        }

        public async Task<ProdutoViewModel> Handle(GetDetalhesProdutoQuery request, CancellationToken cancellationToken)
        {
            var produto = await _produtoRepository.FindByIdAsync(request.Id);

            return new ProdutoViewModel { Id = produto.Id, Descricao = produto.Descricao, Valor = produto.Valor };
        }
    }
}
