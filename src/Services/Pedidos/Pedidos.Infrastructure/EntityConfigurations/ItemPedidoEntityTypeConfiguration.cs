using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Pedidos.Domain.Pedidos;
using Pedidos.Infrastructure.Database;


namespace Pedidos.Infrastructure.EntityConfigurations
{
    public class ItemPedidoEntityTypeConfiguration : IEntityTypeConfiguration<ItemPedido>
    {
        public void Configure(EntityTypeBuilder<ItemPedido> builder)
        {
            builder.ToTable("ItemPedido", PedidosContext.DEFAULT_SCHEMA);

            builder.HasKey(item => new { item.Id, item.PedidoId });
            builder.Ignore(item => item.DomainEvents);

            builder.Property(item => item.QuantidadeItens)
                .IsRequired();

            builder.Property(item => item.ValorItemMomentoCompra)
               .IsRequired()
               .HasColumnType("decimal(10,2)");

            builder.HasOne(item => item.Produto)
                .WithMany()
                .HasForeignKey(item => item.ProdutoId);
        }
    }
}