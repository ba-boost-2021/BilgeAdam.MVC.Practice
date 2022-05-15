using BilgeAdam.Services.Abstractions;
using BilgeAdam.Services.Concretes;
using Microsoft.Extensions.DependencyInjection;

namespace BilgeAdam.Services.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static void AddServices(this IServiceCollection services)
        {
            services.AddScoped<IProductService, ProductService>();
        }
    }
}