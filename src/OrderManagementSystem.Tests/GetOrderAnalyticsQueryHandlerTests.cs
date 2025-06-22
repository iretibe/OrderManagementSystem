using Moq;
using OrderManagementSystem.Application.Queries;
using OrderManagementSystem.Application.Queries.Handlers;
using OrderManagementSystem.Domain.Entities;
using OrderManagementSystem.Domain.Enums;
using OrderManagementSystem.Domain.Repositories;

namespace OrderManagementSystem.Tests
{
    public class GetOrderAnalyticsQueryHandlerTests
    {
        [Fact]
        public async Task Handle_ShouldReturnCorrectAnalytics()
        {
            // Arrange
            var now = DateTime.UtcNow;

            var order1 = CreateTestOrder(100, now.AddHours(-2), OrderStatus.Delivered);
            var order2 = CreateTestOrder(200, now.AddHours(-1), OrderStatus.Delivered);

            var orders = new List<Order> { order1, order2 };

            var repositoryMock = new Mock<IOrderRepository>();
            repositoryMock.Setup(r => r.GetDeliveredOrdersAsync(It.IsAny<CancellationToken>())).ReturnsAsync(orders);

            var handler = new GetOrderAnalyticsQueryHandler(repositoryMock.Object);
            var query = new GetOrderAnalyticsQuery();

            // Act
            var result = await handler.Handle(query, CancellationToken.None);

            // Assert
            Assert.Equal(150, result.AverageOrderValue);
            Assert.True(result.AverageFulfillmentTime > TimeSpan.Zero);
        }

        // Helper to bypass private setter via reflection (for testing only)
        private Order CreateTestOrder(decimal amount, DateTime createdAt, OrderStatus status)
        {
            var order = new Order();
            order.TotalAmount = amount;
            order.CreatedAt = createdAt;

            typeof(Order)
                .GetProperty(nameof(Order.Status))!
                .SetValue(order, status);

            return order;
        }
    }
}
