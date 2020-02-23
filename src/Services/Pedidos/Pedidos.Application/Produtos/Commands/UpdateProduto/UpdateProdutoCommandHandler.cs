using MediatR;
using Pedidos.Domain.Produtos;
using System.Threading;
using System.Threading.Tasks;

namespace Pedidos.Application.Produtos.Commands.UpdateProduto
{
    public class UpdateProdutoCommandHandler : IRequestHandler<UpdateProdutoCommand, bool>
    {
        private readonly IProdutoRepository _produtoRepository;

        public UpdateProdutoCommandHandler(IProdutoRepository produtoRepository)
        {
            _produtoRepository = produtoRepository;
        }

        public Task<bool> Handle(UpdateProdutoCommand request, CancellationToken cancellationToken)
        {
            var produto = _produtoRepository.FindById(request.Id);

            if (produto == null)
                return null;

            produto.Descricao = request.Descricao;
            produto.Valor = request.Valor;

            _produtoRepository.Update(produto);

            return _produtoRepository.UnitOfWork.SaveEntitiesAsync();
        }
    }
}