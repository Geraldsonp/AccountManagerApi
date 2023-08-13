using System;
using ApplicationLayer.Domain.Contracts;
using ApplicationLayer.Services;
using Microsoft.Extensions.DependencyInjection;


namespace ApplicationLayer
{
    public static class ServiceLayerConfiguration
    {
        public static IServiceCollection AddServiceLayer(this IServiceCollection services)
        {
            services.AddScoped<IAccountService, AccountService>();
            services.AddScoped<IClientService, ClientService>();
            services.AddScoped<ITransactionService, TransactionService>();
            services.AddScoped<IReportingService, ReportingService>();
            return services;
        }

    }
}
