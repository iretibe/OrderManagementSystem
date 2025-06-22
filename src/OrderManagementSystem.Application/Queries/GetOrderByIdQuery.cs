using MediatR;
using OrderManagementSystem.Domain.Entities;

namespace OrderManagementSystem.Application.Queries
{
    public class GetOrderByIdQuery : IRequest<Order?>
    {
        public Guid OrderId { get; set; }
    }
}
