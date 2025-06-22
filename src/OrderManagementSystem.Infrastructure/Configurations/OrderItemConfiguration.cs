using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OrderManagementSystem.Domain.Entities;

namespace OrderManagementSystem.Infrastructure.Configurations
{
    public class OrderItemConfiguration : IEntityTypeConfiguration<OrderItem>
    {
        public void Configure(EntityTypeBuilder<OrderItem> builder)
        {
            builder.HasKey(i => i.Id);
            builder.Property(i => i.ProductName).IsRequired().HasMaxLength(100);
            builder.Property(i => i.Price).IsRequired().HasColumnType("decimal(18,2)");
            builder.Property(i => i.Quantity).IsRequired();
        }
    }
}
