using MediatR;
using OrderManagementSystem.Domain.Enums;

namespace OrderManagementSystem.Application.Commands
{
    public class UpdateOrderStatusCommand : IRequest
    {
        public Guid OrderId { get; set; }
        public OrderStatus NewStatus { get; set; }
    }
}
