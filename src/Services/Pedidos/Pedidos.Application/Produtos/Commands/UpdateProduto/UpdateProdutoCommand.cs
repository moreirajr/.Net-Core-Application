using MediatR;
using Pedidos.Application.Produtos.Queries;


namespace Pedidos.Application.Produtos.Commands.UpdateProduto
{
    public class UpdateProdutoCommand : IRequest<bool>
    {
        public int Id { get; set; }

        public string Descricao { get; }

        public double Valor { get; }

        public UpdateProdutoCommand(UpdateProdutoRequest request)
        {
            Id = request.Id;
            Descricao = request.Descricao;
            Valor = request.Valor;
        }
    }
}