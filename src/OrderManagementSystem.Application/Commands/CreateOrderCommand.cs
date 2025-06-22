using MediatR;
using OrderManagementSystem.Domain.Entities;

namespace OrderManagementSystem.Application.Commands
{
    public class CreateOrderCommand : IRequest<Guid>
    {
        public Guid CustomerId { get; set; }
        public decimal TotalAmount { get; set; }
        public List<OrderItem> Items { get; set; } = new List<OrderItem>();
    }
}
