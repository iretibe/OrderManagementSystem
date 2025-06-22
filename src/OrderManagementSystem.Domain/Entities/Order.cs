using OrderManagementSystem.Domain.Enums;

namespace OrderManagementSystem.Domain.Entities
{
    public class Order : BaseEntity
    {
        public Guid CustomerId { get; set; }
        public Customer Customer { get; set; } = default!;
        public decimal TotalAmount { get; set; }
        public DateTime CreatedAt { get; set; }
        public OrderStatus Status { get; private set; }
        public List<OrderItem> Items { get; set; } = new();

        public void InitializeStatus(OrderStatus status)
        {
            Status = status;
        }

        public void UpdateStatus(OrderStatus newStatus)
        {
            if (Status == OrderStatus.Delivered || Status == OrderStatus.Cancelled)
                throw new InvalidOperationException("No transitions allowed from final states.");

            Status = newStatus;
        }

        public void UpdateOrder(decimal totalAmount, List<OrderItem> items)
        {
            TotalAmount = totalAmount;
            Items = items;
        }
    }
}
