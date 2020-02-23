using MediatR;
using Pedidos.Domain.Produtos;
using System.Threading;
using System.Threading.Tasks;

namespace Pedidos.Application.Produtos.Commands.CreateProduto
{
    public class CreateProdutoCommandHandler : IRequestHandler<CreateProdutoCommand, bool>
    {
        private readonly IProdutoRepository _produtoRepository;

        public CreateProdutoCommandHandler(IProdutoRepository produtoRepository)
        {
            _produtoRepository = produtoRepository;
        }

        public async Task<bool> Handle(CreateProdutoCommand request, CancellationToken cancellationToken)
        {
            var novoProduto = new Produto(request.Descricao, request.Valor);

            await _produtoRepository.AddAsync(novoProduto);

            return await _produtoRepository.UnitOfWork.SaveEntitiesAsync(cancellationToken); ;
        }
    }
}