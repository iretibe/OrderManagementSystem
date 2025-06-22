using Microsoft.EntityFrameworkCore;
using OrderManagementSystem.Domain.Entities;
using OrderManagementSystem.Infrastructure.Configurations;

namespace OrderManagementSystem.Infrastructure.Data
{
    public class OrderDbContext : DbContext
    {
        public OrderDbContext(DbContextOptions<OrderDbContext> options) : base(options) { }

        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }
        public DbSet<Customer> Customers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfiguration(new CustomerConfiguration());
            modelBuilder.ApplyConfiguration(new OrderConfiguration());
            modelBuilder.ApplyConfiguration(new OrderItemConfiguration());

            modelBuilder.Entity<Customer>().HasData(
                new Customer 
                { 
                    Id = Guid.Parse("494BC8B2-E605-4019-B4BC-14D2D4A05DC7"), 
                    Name = "Abdul Djalal", 
                    Segment = "VIP" 
                },
                new Customer 
                { 
                    Id = Guid.Parse("66F79247-D93B-4765-A524-88AD3C6418BA"), 
                    Name = "Abdul Manane", 
                    Segment = "Loyal" 
                }
            );
        }
    }
}