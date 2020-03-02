using Pedidos.Domain.Produtos;
using Pedidos.Domain.SeedWork;

namespace Pedidos.Domain.Pedidos
{
    public class ItemPedido : AEntity, IAggregateRoot
    {
        public int PedidoId { get; set; }
        public Pedido Pedido { get; set; }

        public int ProdutoId { get; set; }
        public Produto Produto { get; set; }

        public int QuantidadeItens { get; set; }

        public decimal ValorItemMomentoCompra { get; set; }

        public ItemPedido() { }
        public ItemPedido(int produtoId, decimal valorItem, int qtdItems = 1)
        {
            ProdutoId = produtoId;
            QuantidadeItens = qtdItems;
            ValorItemMomentoCompra = valorItem;
        }
    }
}