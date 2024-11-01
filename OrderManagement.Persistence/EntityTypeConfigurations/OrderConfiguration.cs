using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OrderManagement.Domain;

namespace OrderManagement.Persistence.EntityTypeConfigurations;

public class OrderConfiguration : IEntityTypeConfiguration<Order>
{
    public void Configure(EntityTypeBuilder<Order> builder)
    {
        builder
            .ToTable("orders");
        
        builder
            .HasKey(order => order.Id);
        
        builder
            .HasIndex(order => order.Id)
            .IsUnique();
        
        builder
            .Property(order => order.Id)
            .HasColumnName("id");

        builder
            .Property(order => order.CustomerName)
            .HasColumnName("customer_name")
            .HasMaxLength(250)
            .IsRequired();

        builder
            .Property(order => order.OrderDate)
            .HasColumnName("order_date")
            .IsRequired();

        builder
            .Property(order => order.TotalAmount)
            .HasColumnName("total_amount")
            .HasPrecision(10, 2)
            .IsRequired();
        
        builder
            .Property(order => order.Currency)
            .HasColumnName("currency")
            .IsRequired();
        
        builder
            .Property(order => order.Status)
            .HasColumnName("status")
            .IsRequired();
        
        builder
            .Property(order => order.Priority)
            .HasColumnName("priority")
            .IsRequired();

        builder
            .Property(order => order.TotalAmountInBaseCurrency)
            .HasColumnName("total_amount_in_base_currency")
            .HasPrecision(10, 2);
    }
}