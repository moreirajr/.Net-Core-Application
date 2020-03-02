
namespace Pedidos.Application.Produtos.Commands.CreateProduto
{
    public class CreateProdutoRequest
    {
        public string Descricao { get; set; }

        public double Valor { get; set; }

        public int QuantidadeEstoque { get; set; }
    }
}