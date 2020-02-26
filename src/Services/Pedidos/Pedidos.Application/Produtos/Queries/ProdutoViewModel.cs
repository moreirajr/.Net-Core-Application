using Pedidos.Application.Pagination;

namespace Pedidos.Application.Produtos.Queries
{
    public class ProdutoViewModel : IViewModel
    {
        public int Id { get; set; }

        public string Descricao { get; set; }

        public double Valor { get; set; }

    }
}