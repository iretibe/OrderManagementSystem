using Microsoft.EntityFrameworkCore;
using OrderManagementSystem.Domain.Repositories;
using OrderManagementSystem.Infrastructure.Data;

namespace OrderManagementSystem.Infrastructure.Repositories
{
    public class DiscountRepository : IDiscountRepository
    {
        private readonly OrderDbContext _context;

        public DiscountRepository(OrderDbContext context)
        {
            _context = context;
        }

        public async Task<decimal> ApplyDiscountAsync(Guid orderId, CancellationToken cancellationToken)
        {
            var order = await _context.Orders
                .Include(o => o.Customer)
                .FirstOrDefaultAsync(o => o.Id == orderId, cancellationToken);

            if (order == null) throw new Exception("Order not found");

            decimal discount = 0;
            var segment = order.Customer?.Segment ?? "";

            if (segment == "VIP")
                discount = 0.20m;
            else if (segment == "Loyal" && order.TotalAmount > 500)
                discount = 0.10m;
            else if (order.TotalAmount > 1000)
                discount = 0.05m;

            return order.TotalAmount * (1 - discount);
        }
    }
}
