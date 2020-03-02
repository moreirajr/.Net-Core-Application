using Microsoft.Extensions.DependencyInjection;
using Pagamentos.Domain.Pagamentos;
using Pagamentos.Infrastructure.Repositories;


namespace Pagamentos.Infrastructure.Ioc
{
    public static class ApplicationModule
    {
        public static IServiceCollection ConfigureDependencies(this IServiceCollection services)
        {
            services.AddScoped<IPagamentoRepository, PagamentoRepository>();

            return services;
        }

        public static IServiceCollection ConfigureEF(this IServiceCollection services, string connectionString)
        {
            services.InitializeEFConfiguration(connectionString);

            return services;
        }
    }
}