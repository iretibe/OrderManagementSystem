using MediatR;

namespace OrderManagementSystem.Application.Commands
{
    public class ApplyDiscountCommand : IRequest<decimal>
    {
        public Guid OrderId { get; set; }
    }
}
