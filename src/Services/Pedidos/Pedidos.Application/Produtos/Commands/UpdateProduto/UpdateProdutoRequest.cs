

namespace Pedidos.Application.Produtos.Commands.UpdateProduto
{
    public class UpdateProdutoRequest
    {
        public int Id { get; set; }

        public string Descricao { get; set; }

        public double Valor { get; set; }
    }
}