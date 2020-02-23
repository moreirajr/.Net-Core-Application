using Microsoft.Extensions.DependencyInjection;
using Pedidos.Domain.Produtos;
using Pedidos.Infrastructure.Repositories;


namespace Pedidos.Infrastructure.IoC
{
    public static class ApplicationModule
    {
        public static IServiceCollection ConfigureDependencies(this IServiceCollection services)
        {
            services.AddScoped<IProdutoRepository, ProdutoRepository>();

            return services;
        }

        public static IServiceCollection ConfigureEF(this IServiceCollection services, string connectionString)
        {
            services.InitializeEFConfiguration(connectionString);

            return services;
        }
    }
}