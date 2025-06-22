using MediatR;
using OrderManagementSystem.Application.Exceptions;
using OrderManagementSystem.Domain.Repositories;

namespace OrderManagementSystem.Application.Commands.Handlers
{
    public class UpdateOrderCommandHandler : IRequestHandler<UpdateOrderCommand>
    {
        private readonly IOrderRepository _repository;

        public UpdateOrderCommandHandler(IOrderRepository repository)
        {
            _repository = repository;
        }

        public async Task Handle(UpdateOrderCommand request, CancellationToken cancellationToken)
        {
            var order = await _repository.GetOrderByIdAsync(request.OrderId, cancellationToken);
            if (order == null) throw new OrderNotFoundException(request.OrderId);

            order.UpdateOrder(request.TotalAmount, request.Items);

            await _repository.UpdateOrderAsync(order, cancellationToken);
        }
    }
}
