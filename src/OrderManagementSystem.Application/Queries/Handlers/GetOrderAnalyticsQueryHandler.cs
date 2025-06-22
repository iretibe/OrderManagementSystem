using MediatR;
using OrderManagementSystem.Domain.DTOs;
using OrderManagementSystem.Domain.Repositories;

namespace OrderManagementSystem.Application.Queries.Handlers
{
    public class GetOrderAnalyticsQueryHandler : IRequestHandler<GetOrderAnalyticsQuery, OrderAnalyticsDto>
    {
        private readonly IOrderRepository _repository;

        public GetOrderAnalyticsQueryHandler(IOrderRepository repository)
        {
            _repository = repository;
        }

        public async Task<OrderAnalyticsDto> Handle(GetOrderAnalyticsQuery request, CancellationToken cancellationToken)
        {
            var orders = await _repository.GetDeliveredOrdersAsync(cancellationToken);

            if (!orders.Any())
            {
                return new OrderAnalyticsDto 
                { 
                    AverageOrderValue = 0, 
                    AverageFulfillmentTime = TimeSpan.Zero 
                };
            }

            return new OrderAnalyticsDto
            {
                AverageOrderValue = orders.Average(o => o.TotalAmount),
                AverageFulfillmentTime = TimeSpan.FromTicks((long)orders.Average(o => (DateTime.UtcNow - o.CreatedAt).Ticks))
            };
        }
    }
}
