using Hangfire;
using Hangfire.PostgreSql;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;

namespace OrderManagement.BackgroundJobs;

public static class DependencyInjection
{
    private const string KeyConnectionString = "DbBackgroundJobConnection";

    public static IServiceCollection AddDependencyBackgroundJobs(this IServiceCollection services, IConfiguration configuration)
    {
        var connectionString = configuration[KeyConnectionString];
        services.AddTransient<OrderBackgroundJob>(); 
        services.AddHangfireServer();
        services.AddHangfire(x =>
            x.UsePostgreSqlStorage(connectionString));
        
        return services;
    }
    
}