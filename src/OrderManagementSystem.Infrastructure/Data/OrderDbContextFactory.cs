using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace OrderManagementSystem.Infrastructure.Data
{
    public class OrderDbContextFactory : IDesignTimeDbContextFactory<OrderDbContext>
    {
        public OrderDbContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<OrderDbContext>();

            optionsBuilder.UseSqlServer("Server=PSL-SYESSOUFOU\\SQL2022;Database=Order_Manager_DB;User ID=sa;Password=Persol@2023;Trusted_Connection=False;MultipleActiveResultSets=True;TrustServerCertificate=True");

            return new OrderDbContext(optionsBuilder.Options);
        }
    }
}
