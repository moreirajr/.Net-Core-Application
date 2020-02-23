using System;
using System.Reflection;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using Pedidos.Application.Produtos.Queries.GetListaProdutos;
using Pedidos.Infrastructure.IoC;

namespace Pedidos.Api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services
                .AddMvcConfiguration()
                .AddEFConfiguration(Configuration)
                .AddSwaggerConfiguration(Configuration)
                .AddMediatorConfiguration()
                .ConfigureDependencies();   //ApplicationModule

            //ApplicationModule.ConfigureDependencies(services);
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseCors("CorsPolicy");

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            app.UseSwagger()
                .UseSwaggerUI(c =>
                {
                    c.SwaggerEndpoint("/swagger/v1/swagger.json", "Pedidos.Api v1");
                });
        }
    }

    static class StartupConfigExtensionsMethods
    {
        public static IServiceCollection AddMvcConfiguration(this IServiceCollection services)
        {
            services.AddControllers();

            services.AddCors(options =>
            {
                options.AddPolicy("CorsPolicy",
                    builder => builder.SetIsOriginAllowed((host) => true)
                    .AllowAnyMethod()
                    .AllowAnyHeader()
                    .AllowCredentials());
            });

            return services;
        }

        public static IServiceCollection AddEFConfiguration(this IServiceCollection services, IConfiguration configuration)
        {
            return services.ConfigureEF(configuration.GetConnectionString("local"));
        }

        public static IServiceCollection AddSwaggerConfiguration(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "Pedidos Api",
                    Version = "v1",
                    Description = "Serviço da Api de Pedidos"
                });
            });

            return services;
        }

        public static IServiceCollection AddMediatorConfiguration(this IServiceCollection services)
        {
            var pedidosApplicationAssembly = AppDomain.CurrentDomain.Load("Pedidos.Application");
            
            services.AddMediatR(pedidosApplicationAssembly);

            return services;
        }

    }
}