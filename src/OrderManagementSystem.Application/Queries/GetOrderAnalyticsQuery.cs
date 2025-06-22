using MediatR;
using OrderManagementSystem.Domain.DTOs;

namespace OrderManagementSystem.Application.Queries
{
    public class GetOrderAnalyticsQuery : IRequest<OrderAnalyticsDto> { }
}
