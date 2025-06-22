using MediatR;
using OrderManagementSystem.Domain.Entities;
using OrderManagementSystem.Domain.Enums;
using OrderManagementSystem.Domain.Repositories;

namespace OrderManagementSystem.Application.Commands.Handlers
{
    public class CreateOrderCommandHandler : IRequestHandler<CreateOrderCommand, Guid>
    {
        private readonly IOrderRepository _repository;

        public CreateOrderCommandHandler(IOrderRepository repository)
        {
            _repository = repository;
        }

        public async Task<Guid> Handle(CreateOrderCommand request, CancellationToken cancellationToken)
        {
            var order = new Order
            {
                Id = Guid.NewGuid(),
                CustomerId = request.CustomerId,
                TotalAmount = request.TotalAmount,
                CreatedAt = DateTime.UtcNow,
                Items = request.Items
            };

            order.InitializeStatus(OrderStatus.Created);

            await _repository.CreateOrderAsync(order, cancellationToken);

            return order.Id;
        }
    }
}
