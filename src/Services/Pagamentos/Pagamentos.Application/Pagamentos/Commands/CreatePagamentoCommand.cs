using MediatR;
using System;

namespace Pagamentos.Application.Pagamentos.Commands
{
    public class CreatePagamentoCommand : IRequest<bool>
    {
        public int PedidoId { get; set; }
        public DateTime DataPagamento { get; set; }

        public CreatePagamentoCommand(CreatePagamentoRequest request)
        {
            PedidoId = request.PedidoId;
            DataPagamento = request.DataPagamento;
        }
    }
}