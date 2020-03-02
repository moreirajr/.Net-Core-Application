using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Pagamentos.Infrastructure.Database;
using System;

namespace Pagamentos.Infrastructure
{
    public static class EFConfiguration
    {
        public static IServiceCollection InitializeEFConfiguration(this IServiceCollection services, string connectionString)
        {
            services.AddEntityFrameworkSqlServer()
                .AddDbContext<PagamentosContext>(options =>
                {
                    options.UseSqlServer(connectionString,
                        sqlServerOptionsAction: sqlOptions =>
                        {
                            sqlOptions.MigrationsAssembly("Pagamentos.Infrastructure");
                            sqlOptions.EnableRetryOnFailure(maxRetryCount: 15, maxRetryDelay: TimeSpan.FromSeconds(30), errorNumbersToAdd: null);
                        });
                },
                ServiceLifetime.Scoped
            );

            return services;
        }
    }
}