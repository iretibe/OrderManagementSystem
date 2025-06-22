using Microsoft.EntityFrameworkCore;
using OrderManagementSystem.Domain.Entities;
using OrderManagementSystem.Domain.Enums;
using OrderManagementSystem.Domain.Repositories;
using OrderManagementSystem.Infrastructure.Data;

namespace OrderManagementSystem.Infrastructure.Repositories
{
    public class OrderRepository : IOrderRepository
    {
        private readonly OrderDbContext _context;

        public OrderRepository(OrderDbContext context)
        {
            _context = context;
        }

        public async Task CreateOrderAsync(Order order, CancellationToken cancellationToken)
        {
            await _context.Orders.AddAsync(order, cancellationToken);
            await _context.SaveChangesAsync();
        }

        public async Task<List<Order>> GetDeliveredOrdersAsync(CancellationToken cancellationToken)
        {
            return await _context.Orders
                .Where(o => o.Status == OrderStatus.Delivered)
                .ToListAsync(cancellationToken);
        }

        public async Task<Order> GetOrderByIdAsync(Guid orderId, CancellationToken cancellationToken)
        {
            var order = await _context.Orders
                .Include(o => o.Items)
                .FirstOrDefaultAsync(o => o.Id == orderId, cancellationToken);

            return order!;
        }

        public async Task UpdateOrderAsync(Order order, CancellationToken cancellationToken)
        {
            _context.Orders.Update(order);
            await _context.SaveChangesAsync();
        }
    }
}
