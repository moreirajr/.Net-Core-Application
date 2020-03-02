using Pedidos.Domain.SeedWork;
using System.Collections;
using System.Collections.Generic;

namespace Pedidos.Domain.Pedidos
{
    public class StatusPedido : Enumeration
    {
        public static StatusPedido PedidoRecebido = new StatusPedido(1, "Pedido recebido");

        public static StatusPedido AguardandoPagamento = new StatusPedido(2, "Aguardando confirmação pagamento");

        public static StatusPedido PagamentoConfirmado = new StatusPedido(3, "Pagamento confirmado");

        public static StatusPedido EmEntrega = new StatusPedido(4, "Em entrega");

        public static StatusPedido PedidoEntregue = new StatusPedido(5, "Pedido entregue");

        public static StatusPedido Cancelado = new StatusPedido(9, "Cancelado");

        public StatusPedido(int id, string name) : base(id, name)
        {
        }

        public static IEnumerable<StatusPedido> StatusList
        {
            get
            {
                return new List<StatusPedido> {
                    StatusPedido.PedidoRecebido,
                    StatusPedido.AguardandoPagamento,
                    StatusPedido.PagamentoConfirmado,
                    StatusPedido.EmEntrega,
                    StatusPedido.PedidoEntregue,
                    StatusPedido.Cancelado,
                };
            }
        }
    }
}