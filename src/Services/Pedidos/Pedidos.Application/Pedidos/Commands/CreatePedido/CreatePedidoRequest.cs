using System.Collections.Generic;

namespace Pedidos.Application.Pedidos.Commands.CreatePedido
{
    public class CreatePedidoRequest
    {
        public int ClienteId { get; set; }

        public ICollection<CreateItemPedidoRequest> Itens { get; set; }

    }
}