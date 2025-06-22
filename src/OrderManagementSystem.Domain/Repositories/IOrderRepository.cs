using OrderManagementSystem.Domain.Entities;

namespace OrderManagementSystem.Domain.Repositories
{
    public interface IOrderRepository
    {
        Task<List<Order>> GetDeliveredOrdersAsync(CancellationToken cancellationToken);
        Task<Order> GetOrderByIdAsync(Guid orderId, CancellationToken cancellationToken);
        Task CreateOrderAsync(Order order, CancellationToken cancellationToken);
        Task UpdateOrderAsync(Order order, CancellationToken cancellationToken);
    }
}
