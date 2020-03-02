using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Pedidos.Domain.Produtos;
using Pedidos.Infrastructure.Database;

namespace Pedidos.Infrastructure.EntityConfigurations
{
    public class ProdutoEntityTypeConfiguration : IEntityTypeConfiguration<Produto>
    {
        public void Configure(EntityTypeBuilder<Produto> builder)
        {
            builder.ToTable("Produto", PedidosContext.DEFAULT_SCHEMA);

            builder.HasKey(p => p.Id);
            builder.Ignore(p => p.DomainEvents);

            builder.Property(p => p.Descricao)
                .IsRequired()
                .HasMaxLength(70);

            builder.Property(p => p.Valor)
                .IsRequired()
                .HasColumnType("decimal(10,2)");

            builder.Property(p => p.QuantidadeEstoque)
                .IsRequired();
        }
    }
}