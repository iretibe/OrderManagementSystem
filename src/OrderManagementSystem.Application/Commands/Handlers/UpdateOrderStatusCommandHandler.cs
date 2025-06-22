using MediatR;
using OrderManagementSystem.Application.Exceptions;
using OrderManagementSystem.Domain.Repositories;

namespace OrderManagementSystem.Application.Commands.Handlers
{
    public class UpdateOrderStatusCommandHandler : IRequestHandler<UpdateOrderStatusCommand>
    {
        private readonly IOrderRepository _repository;

        public UpdateOrderStatusCommandHandler(IOrderRepository repository)
        {
            _repository = repository;
        }

        public async Task Handle(UpdateOrderStatusCommand request, CancellationToken cancellationToken)
        {
            var order = await _repository.GetOrderByIdAsync(request.OrderId, cancellationToken);
            if (order == null) throw new OrderNotFoundException(request.OrderId);

            order.UpdateStatus(request.NewStatus);

            await _repository.UpdateOrderAsync(order, cancellationToken);
        }
    }
}
