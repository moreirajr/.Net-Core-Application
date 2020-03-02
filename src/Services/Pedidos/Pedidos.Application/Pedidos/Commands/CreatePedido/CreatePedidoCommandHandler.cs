using MediatR;
using Pedidos.Domain.Pedidos;
using Pedidos.Domain.Produtos;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Pedidos.Application.Pedidos.Commands.CreatePedido
{
    public class CreatePedidoCommandHandler : IRequestHandler<CreatePedidoCommand, bool>
    {
        private readonly IProdutoRepository _produtoRepository;
        private readonly IPedidoRepository _pedidoRepository;

        public CreatePedidoCommandHandler(IProdutoRepository produtoRepository, IPedidoRepository pedidoRepository)
        {
            _produtoRepository = produtoRepository;
            _pedidoRepository = pedidoRepository;
        }

        public async Task<bool> Handle(CreatePedidoCommand request, CancellationToken cancellationToken)
        {
            var itensProduto = request.Itens.Select(x => new { Id = x.ProdutoId, Qtd = x.QuantidadeItens });
            var produtos = await _produtoRepository.FindAllByIdAsync(itensProduto.Select(x => x.Id).ToArray());

            var produtosEstoque = produtos.Select(x => new
            {
                Id = x.Id,
                EstoqueAtualizado = x.QuantidadeEstoque - itensProduto.FirstOrDefault(y => y.Id == x.Id).Qtd
            });

            if (produtosEstoque.Any(x => x.EstoqueAtualizado < 0))
                return false;

            var novoPedido = new Pedido(request.ClienteId);
            var itensPedido = request.Itens.Select(x => new ItemPedido(x.ProdutoId, x.ValorItemMomentoCompra, x.QuantidadeItens));

            await SalvarPedido(novoPedido, itensPedido);

            foreach (var produto in produtos)
            {
                produto.QuantidadeEstoque = produtosEstoque.FirstOrDefault(y => y.Id == produto.Id).EstoqueAtualizado;
                _produtoRepository.Update(produto);
            }

            await _produtoRepository.UnitOfWork.SaveEntitiesAsync();

            return true;
        }

        private async Task SalvarPedido(Pedido pedido, IEnumerable<ItemPedido> itens)
        {
            await _pedidoRepository.BeginTransactionAsync();

            _pedidoRepository.Add(pedido);
            await _pedidoRepository.UnitOfWork.SaveChangesAsync();

            _pedidoRepository.AddItensPedido(pedido.Id, itens);
            await _pedidoRepository.UnitOfWork.SaveChangesAsync();

            await _pedidoRepository.CommitTransactionAsync();
        }
    }
}