using Pedidos.Domain.SeedWork;
using System;
using System.Collections.Generic;

namespace Pedidos.Domain.Pedidos
{
    public class Pedido : AEntity, IAggregateRoot
    {
        public int ClienteId { get; set; }

        public DateTime DataCompra { get; set; }

        public int StatusId { get; set; }
        public StatusPedido Status { get; set; }

        public ICollection<ItemPedido> Itens { get; set; }


        public Pedido() { }
        public Pedido(int clienteId)
        {
            ClienteId = clienteId;
            Itens = new List<ItemPedido>();
            StatusId = StatusPedido.PedidoRecebido.Id;
            DataCompra = DateTime.UtcNow;
        }
    }
}