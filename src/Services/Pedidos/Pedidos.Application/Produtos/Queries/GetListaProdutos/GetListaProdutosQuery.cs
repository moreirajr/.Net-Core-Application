using MediatR;
using System.Collections.Generic;


namespace Pedidos.Application.Produtos.Queries.GetListaProdutos
{
    public class GetListaProdutosQuery : IRequest<IList<ProdutoViewModel>>
    {
        public GetListaProdutosQuery()
        {

        }
    }
}