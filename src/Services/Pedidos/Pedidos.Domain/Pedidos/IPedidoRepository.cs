using Pedidos.Domain.SeedWork;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Pedidos.Domain.Pedidos
{
    public interface IPedidoRepository : IRepository<Pedido>
    {
        void Add(Pedido pedido);
        void AddItensPedido(int pedidoId, IEnumerable<ItemPedido> itens);

        Pedido GetPedidoById(int id);

        Task<IEnumerable<Pedido>> GetPedidosByCliente(int clienteId);

        Task BeginTransactionAsync();
        Task CommitTransactionAsync();
    }
}