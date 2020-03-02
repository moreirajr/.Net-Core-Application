using MediatR;
using System.Collections.Generic;

namespace Pedidos.Application.Pedidos.Commands.CreatePedido
{
    public class CreatePedidoCommand : IRequest<bool>
    {
        public int ClienteId { get; set; }

        public ICollection<CreateItemPedidoRequest> Itens { get; set; }

        public CreatePedidoCommand(CreatePedidoRequest request)
        {
            ClienteId = request.ClienteId;
            Itens = request.Itens;
        }
    }
}