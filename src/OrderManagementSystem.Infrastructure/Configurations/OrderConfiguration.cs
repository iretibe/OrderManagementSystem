using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OrderManagementSystem.Domain.Entities;

namespace OrderManagementSystem.Infrastructure.Configurations
{
    public class OrderConfiguration : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder.HasKey(o => o.Id);
            builder.Property(o => o.TotalAmount).IsRequired().HasColumnType("decimal(18,2)");
            builder.Property(o => o.CreatedAt).IsRequired();
            builder.Property(o => o.Status).IsRequired();
            builder.HasMany(o => o.Items)
                   .WithOne()
                   .HasForeignKey(i => i.OrderId)
                   .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
