using Moq;
using OrderManagementSystem.Application.Commands;
using OrderManagementSystem.Application.Commands.Handlers;
using OrderManagementSystem.Domain.Repositories;

namespace OrderManagementSystem.Tests
{
    public class ApplyDiscountCommandHandlerTests
    {
        [Fact]
        public async Task Handle_ShouldApplyCorrectDiscount()
        {
            // Arrange
            var orderId = Guid.NewGuid();
            var discountServiceMock = new Mock<IDiscountRepository>();
            discountServiceMock.Setup(s => s.ApplyDiscountAsync(orderId, It.IsAny<CancellationToken>())).ReturnsAsync(90);

            var handler = new ApplyDiscountCommandHandler(discountServiceMock.Object);
            var command = new ApplyDiscountCommand { OrderId = orderId };

            // Act
            var result = await handler.Handle(command, CancellationToken.None);

            // Assert
            Assert.Equal(90, result);
        }
    }
}
