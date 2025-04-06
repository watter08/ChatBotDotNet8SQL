using ImproveAbilityInSqlAndC_.Application.Mappings;
using Microsoft.Extensions.DependencyInjection;

namespace ImproveAbilityInSqlAndC_.Application.Extensions
{
    public static class AutoMapperExtensions
    {
        public static IServiceCollection AddApplicationMapings(this IServiceCollection services)
        {
            services.AddAutoMapper(typeof(ProductsProfile));
            return services;
        }
    }
}
