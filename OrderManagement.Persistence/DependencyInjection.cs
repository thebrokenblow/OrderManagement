using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using OrderManagement.Application.Interfaces;
using OrderManagement.Persistence.Repositories;

namespace OrderManagement.Persistence;

public static class DependencyInjection
{
    private const string KeyConnectionString = "DbConnection";
    
    public static IServiceCollection AddPersistence(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<OrderManagementDbContext>(options =>
        {
            options.UseNpgsql(configuration.GetConnectionString(KeyConnectionString));
        });
        
        services.AddScoped<IOrderRepository, OrderRepository>();

        return services;
    }
}