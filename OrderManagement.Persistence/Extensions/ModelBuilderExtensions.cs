﻿using System.Reflection;
using Microsoft.EntityFrameworkCore;

namespace OrderManagement.Persistence.Extensions;

public static class ModelBuilderExtensions
{
    public static void ApplyAllConfigurations(this ModelBuilder modelBuilder)
    {
        var typesToRegister = Assembly.GetExecutingAssembly().GetTypes().Where(t => t.GetInterfaces()
            .Any(gi => gi.IsGenericType && gi.GetGenericTypeDefinition() == typeof(IEntityTypeConfiguration<>))).ToList();

        var configurations = typesToRegister.Select(type => Activator.CreateInstance(type)
                                                            ?? throw new Exception());
        
        foreach (var configuration in configurations)
        {
            modelBuilder.ApplyConfiguration((dynamic) configuration);
        }
    }
}