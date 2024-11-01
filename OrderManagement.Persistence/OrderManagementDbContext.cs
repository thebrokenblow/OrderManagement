using OrderManagement.Domain;
using OrderManagement.Persistence.Extensions;
using Microsoft.EntityFrameworkCore;

namespace OrderManagement.Persistence;

public class OrderManagementDbContext : DbContext
{
    public DbSet<Order> Orders { get; init; }
    
    public OrderManagementDbContext(DbContextOptions<OrderManagementDbContext> options) : base(options) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyAllConfigurations();
        base.OnModelCreating(modelBuilder);
    }
}