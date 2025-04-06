using ImproveAbilityInSqlAndC_.Application.Interfaces.Patterns;
using ImproveAbilityInSqlAndC_.Application.Interfaces.Repositories;
using ImproveAbilityInSqlAndC_.Application.Interfaces.Services;
using ImproveAbilityInSqlAndC_.Infrastructure.Context;
using ImproveAbilityInSqlAndC_.Infrastructure.Patterns;
using ImproveAbilityInSqlAndC_.Infrastructure.Repositories;
using ImproveAbilityInSqlAndC_.Infrastructure.Services.Product;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace ImproveAbilityInSqlAndC_.Infrastructure.Extensions
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<AdoNetContext>(provider =>
            {
                var connectioString = configuration.GetConnectionString("DefaultConnection") ?? "";
                return new AdoNetContext(connectioString);
            });

            services.AddSingleton<IQueryFactory, QueryFactory>();
            services.AddScoped<IGenericRepository, GenericRepository>();
            return services;
        }

        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddScoped<IProductServices, ProductServices>();
            return services;
        }
    }
}
