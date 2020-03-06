using System;

namespace Pagamentos.Application.Pagamentos.Commands
{
    public class CreatePagamentoRequest
    {
        public int PedidoId { get; set; }
        public DateTime DataPagamento { get; set; }

        public CreatePagamentoRequest(int pedidoId, DateTime dataPagamento)
        {
            PedidoId = pedidoId;
            DataPagamento = dataPagamento;
        }
    }
}