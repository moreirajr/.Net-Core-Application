using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Pedidos.Domain.Pedidos;
using Pedidos.Infrastructure.Database;


namespace Pedidos.Infrastructure.EntityConfigurations
{
    public class PedidoEntityTypeConfiguration : IEntityTypeConfiguration<Pedido>
    {
        public void Configure(EntityTypeBuilder<Pedido> builder)
        {
            builder.ToTable("Pedido", PedidosContext.DEFAULT_SCHEMA);

            builder.HasKey(p => p.Id);
            builder.Ignore(p => p.DomainEvents);

            builder.Property(p => p.ClienteId)
                .IsRequired();

            builder.Property(p => p.DataCompra)
                .IsRequired();

            builder.Property(p => p.StatusId)
                .IsRequired();

            builder.HasMany(p => p.Itens)
                .WithOne(item => item.Pedido)
                .HasForeignKey(item => item.PedidoId);

            builder.HasOne(p => p.Status)
                .WithMany()
                .HasForeignKey(p => p.StatusId);
        }
    }
}