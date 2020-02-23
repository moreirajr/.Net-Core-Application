using Pedidos.Domain.SeedWork;


namespace Pedidos.Domain.Produtos
{
    public class Produto : IAggregateRoot
    {
        public int Id { get; set; }

        public string Descricao { get; set; }

        public double Valor { get; set; }

        public Produto(string descricao, double valor)
        {
            Descricao = descricao;
            Valor = valor;
        }
    }
}