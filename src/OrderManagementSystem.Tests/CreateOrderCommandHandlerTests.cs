using Moq;
using OrderManagementSystem.Application.Commands;
using OrderManagementSystem.Application.Commands.Handlers;
using OrderManagementSystem.Domain.Entities;
using OrderManagementSystem.Domain.Repositories;

namespace OrderManagementSystem.Tests
{
    public class CreateOrderCommandHandlerTests
    {
        [Fact]
        public async Task Handle_ValidCommand_ShouldReturnNewOrderId()
        {
            // Arrange
            var repositoryMock = new Mock<IOrderRepository>();
            var handler = new CreateOrderCommandHandler(repositoryMock.Object);
            var command = new CreateOrderCommand
            {
                CustomerId = Guid.NewGuid(),
                TotalAmount = 100,
                Items = new List<OrderItem> { new OrderItem { ProductName = "Test", Price = 50, Quantity = 2 } }
            };

            // Act
            var result = await handler.Handle(command, CancellationToken.None);

            // Assert
            Assert.NotEqual(Guid.Empty, result);
            repositoryMock.Verify(r => r.CreateOrderAsync(It.IsAny<Order>(), It.IsAny<CancellationToken>()), Times.Once);
        }
    }
}
