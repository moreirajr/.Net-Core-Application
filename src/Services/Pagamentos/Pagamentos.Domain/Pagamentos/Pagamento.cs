using Pagamentos.Domain.SeedWork;
using System;

namespace Pagamentos.Domain.Pagamentos
{
    public class Pagamento : AEntity, IAggregateRoot
    {
        public int PedidoId { get; set; }
        public DateTime DataPagamento { get; set; }
    }
}