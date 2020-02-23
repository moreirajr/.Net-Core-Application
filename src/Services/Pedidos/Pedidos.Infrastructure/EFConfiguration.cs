using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Pedidos.Infrastructure.Database;
using System;

namespace Pedidos.Infrastructure
{
    public static class EFConfiguration
    {
        public static IServiceCollection InitializeEFConfiguration(this IServiceCollection services, string connectionString)
        {
            services.AddEntityFrameworkSqlServer()
                .AddDbContext<PedidosContext>(options =>
                {
                    options.UseSqlServer(connectionString,
                        sqlServerOptionsAction: sqlOptions =>
                        {
                            sqlOptions.MigrationsAssembly("Pedidos.Infrastructure");
                            sqlOptions.EnableRetryOnFailure(maxRetryCount: 15, maxRetryDelay: TimeSpan.FromSeconds(30), errorNumbersToAdd: null);
                        });
                },
                ServiceLifetime.Scoped
            );

            return services;
        }
    }
}