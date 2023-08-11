using DataAccessLayer.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace DataAccessLayer;

public static class ServicesConfiguration
{
    public static IServiceCollection RegisterDalServices(this IServiceCollection services, IConfiguration config)
    {
        var connectionString = config.GetConnectionString("DbConnection");
        services.AddDbContext<AccountMngDbContext>(options => options.UseSqlServer(connectionString));
        
        
        return services;
    }
}