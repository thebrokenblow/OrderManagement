using System.Reflection;
using Hangfire;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using OrderManagement.Application.Common.Mappings;
using OrderManagement.Application.Common.Repositories;
using OrderManagement.Application.Common.Repositories.Interfaces;
using OrderManagement.Application.Common.Services;
using OrderManagement.Application.Common.Services.Interfaces;

namespace OrderManagement.Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddTransient<IFileRepository, FileRepository>();
        services.AddTransient<ICurrencyConversion, CurrencyConversion>();
        services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(Assembly.GetExecutingAssembly()));
        services.AddAutoMapper(config =>
        {
            config.AddProfile(new AssemblyMappingProfile(Assembly.GetExecutingAssembly()));
        });
        
        return services;
    }
}