using Microsoft.EntityFrameworkCore;
using Pedidos.Domain.Pedidos;
using Pedidos.Domain.SeedWork;
using Pedidos.Infrastructure.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace Pedidos.Infrastructure.Repositories
{
    public class PedidoRepository : IPedidoRepository
    {
        private readonly PedidosContext _context;

        public IUnitOfWork UnitOfWork
        {
            get { return _context; }
        }

        public PedidoRepository(PedidosContext pedidosContext)
        {
            _context = pedidosContext ?? throw new ArgumentNullException(nameof(pedidosContext));
        }

        public async Task BeginTransactionAsync()
        {
            await _context.BeginTransactionAsync();
        }

        public async Task CommitTransactionAsync()
        {
            await _context.CommitTransactionAsync(_context.GetCurrentTransaction());
        }

        public void Add(Pedido pedido)
        {
            _context.Add(pedido);
        }

        public void AddItensPedido(int pedidoId, IEnumerable<ItemPedido> itens)
        {
            foreach (var item in itens)
            {
                item.PedidoId = pedidoId;
                _context.ItensPedido.Add(item);
            }
        }

        public Pedido GetPedidoById(int id)
        {
            return _context.Pedidos
                .Include(x => x.Itens)
                .FirstOrDefault(x => x.Id == id);
        }

        public async Task<IEnumerable<Pedido>> GetPedidosByCliente(int clienteId)
        {
            return await _context.Pedidos
                .Include(x => x.Itens)
                .Where(x => x.ClienteId == clienteId)
                .ToListAsync();
        }

    }
}