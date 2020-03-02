using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Pagamentos.Domain.Pagamentos;
using Pagamentos.Infrastructure.Database;


namespace Pagamentos.Infrastructure.EntityConfigurations
{
    public class PagamentoEntityTypeConfiguration : IEntityTypeConfiguration<Pagamento>
    {
        public void Configure(EntityTypeBuilder<Pagamento> builder)
        {
            builder.ToTable("Pagamentos", PagamentosContext.DEFAULT_SCHEMA);

            builder.HasKey(p => p.Id);
            builder.Ignore(p => p.DomainEvents);

            builder.Property(p => p.DataPagamento)
                .IsRequired();

            builder.Property(p => p.PedidoId)
                .IsRequired();
        }
    }
}