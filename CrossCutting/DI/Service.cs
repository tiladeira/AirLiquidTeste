using Domain.Application.Services;
using Domain.Application.Services.Interfaces;

using Microsoft.Extensions.DependencyInjection;

namespace CrossCutting.DI
{
    public static class Service
    {
        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            services.AddScoped<IClienteService, ClienteService>();

            return services;
        }
    }
}
