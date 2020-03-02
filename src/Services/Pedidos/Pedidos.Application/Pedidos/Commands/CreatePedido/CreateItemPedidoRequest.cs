

namespace Pedidos.Application.Pedidos.Commands.CreatePedido
{
    public class CreateItemPedidoRequest
    {
        public int ProdutoId { get; set; }

        public int QuantidadeItens { get; set; }

        public decimal ValorItemMomentoCompra { get; set; }
    }
}