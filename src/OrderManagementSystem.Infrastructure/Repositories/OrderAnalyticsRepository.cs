using OrderManagementSystem.Domain.Enums;
using OrderManagementSystem.Domain.Repositories;
using OrderManagementSystem.Infrastructure.Data;

namespace OrderManagementSystem.Infrastructure.Repositories
{
    public class OrderAnalyticsRepository : IOrderAnalyticsRepository
    {
        private readonly OrderDbContext _context;

        public OrderAnalyticsRepository(OrderDbContext context)
        {
            _context = context;
        }

        public TimeSpan GetAverageFulfillmentTime()
        {
            var deliveredOrders = _context.Orders
                .Where(o => o.Status == OrderStatus.Delivered)
                .ToList();

            return deliveredOrders.Any()
                ? TimeSpan.FromTicks((long)deliveredOrders.Average(o => (DateTime.UtcNow - o.CreatedAt).Ticks))
                : TimeSpan.Zero;
        }

        public decimal GetAverageOrderValue()
        {
            return _context.Orders.Any()
                ? _context.Orders.Average(o => o.TotalAmount)
                : 0;
        }
    }
}
