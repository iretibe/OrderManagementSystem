using MediatR;
using OrderManagementSystem.Domain.Entities;

namespace OrderManagementSystem.Application.Commands
{
    public class UpdateOrderCommand : IRequest
    {
        public Guid OrderId { get; set; }
        public decimal TotalAmount { get; set; }
        public List<OrderItem> Items { get; set; } = new List<OrderItem>();
    }
}
