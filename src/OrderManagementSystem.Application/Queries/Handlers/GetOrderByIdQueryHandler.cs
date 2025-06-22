using MediatR;
using OrderManagementSystem.Domain.Entities;
using OrderManagementSystem.Domain.Repositories;

namespace OrderManagementSystem.Application.Queries.Handlers
{
    public class GetOrderByIdQueryHandler : IRequestHandler<GetOrderByIdQuery, Order?>
    {
        private readonly IOrderRepository _repository;

        public GetOrderByIdQueryHandler(IOrderRepository repository)
        {
            _repository = repository;
        }

        public async Task<Order?> Handle(GetOrderByIdQuery request, CancellationToken cancellationToken)
        {
            return await _repository.GetOrderByIdAsync(request.OrderId, cancellationToken);
        }
    }
}
