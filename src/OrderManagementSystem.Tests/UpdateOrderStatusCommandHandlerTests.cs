using Moq;
using OrderManagementSystem.Application.Commands;
using OrderManagementSystem.Application.Commands.Handlers;
using OrderManagementSystem.Domain.Entities;
using OrderManagementSystem.Domain.Enums;
using OrderManagementSystem.Domain.Repositories;

namespace OrderManagementSystem.Tests
{
    public class UpdateOrderStatusCommandHandlerTests
    {
        [Fact]
        public async Task Handle_ValidStatusUpdate_ShouldSucceed()
        {
            // Arrange
            var order = CreateTestOrder(Guid.NewGuid(), 100, OrderStatus.Created);

            var repositoryMock = new Mock<IOrderRepository>();
            repositoryMock.Setup(r => r.GetOrderByIdAsync(order.Id, It.IsAny<CancellationToken>()))
                          .ReturnsAsync(order);

            var handler = new UpdateOrderStatusCommandHandler(repositoryMock.Object);
            var command = new UpdateOrderStatusCommand
            {
                OrderId = order.Id,
                NewStatus = OrderStatus.Shipped
            };

            // Act
            await handler.Handle(command, CancellationToken.None);

            // Assert
            Assert.Equal(OrderStatus.Shipped, order.Status);
            repositoryMock.Verify(r => r.UpdateOrderAsync(order, It.IsAny<CancellationToken>()), Times.Once);
        }

        private Order CreateTestOrder(Guid customerId, decimal amount, OrderStatus status)
        {
            var order = new Order
            {
                Id = Guid.NewGuid(),
                CustomerId = customerId,
                TotalAmount = amount,
                CreatedAt = DateTime.UtcNow,
                Items = new List<OrderItem>()
            };

            typeof(Order)
                .GetProperty(nameof(Order.Status))!
                .SetValue(order, status);

            return order;
        }
    }
}