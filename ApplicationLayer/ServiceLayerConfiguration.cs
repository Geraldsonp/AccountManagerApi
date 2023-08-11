using System;
using ApplicationLayer.Services;
using Microsoft.Extensions.DependencyInjection;


namespace ApplicationLayer
{
    public static class ServiceLayerConfiguration
    {
        public static IServiceCollection AddServiceLayer(this IServiceCollection services)
        {
            services.AddScoped<IAccountService, AccountService>();
            services.AddScoped<IAccountService, AccountService>();
            return services;
        }

    }
}
