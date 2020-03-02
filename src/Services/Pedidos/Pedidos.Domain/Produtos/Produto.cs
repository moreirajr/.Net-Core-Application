using Pedidos.Domain.Exceptions;
using Pedidos.Domain.SeedWork;


namespace Pedidos.Domain.Produtos
{
    public class Produto : AEntity, IAggregateRoot
    {
        public string Descricao { get; set; }

        public double Valor { get; set; }

        public int QuantidadeEstoque { get; set; }


        public Produto() { }
        public Produto(string descricao, double valor, int quantidadeEstoque)
        {
            Descricao = !string.IsNullOrEmpty(descricao) ? descricao : throw new ProdutoDomainException(nameof(descricao));
            Valor = valor > 0 ? valor : throw new ProdutoDomainException(nameof(valor));
            QuantidadeEstoque = quantidadeEstoque > 0 ? quantidadeEstoque : throw new ProdutoDomainException(nameof(quantidadeEstoque));
        }
    }
}