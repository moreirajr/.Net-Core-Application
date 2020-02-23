using MediatR;

namespace Pedidos.Application.Produtos.Queries.GetDetalhesProduto
{
    public class GetDetalhesProdutoQuery : IRequest<ProdutoViewModel>
    {
        public int Id { get; set; }

        public GetDetalhesProdutoQuery(int id)
        {
            Id = id;
        }
    }
}