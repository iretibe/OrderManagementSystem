using Moq;
using OrderManagementSystem.Application.Commands;
using OrderManagementSystem.Application.Commands.Handlers;
using OrderManagementSystem.Domain.Entities;
using OrderManagementSystem.Domain.Repositories;

namespace OrderManagementSystem.Tests
{
    public class CreateCustomerCommandHandlerTests
    {
        [Fact]
        public async Task Handle_ValidCustomer_ShouldReturnNewCustomerId()
        {
            // Arrange
            var repositoryMock = new Mock<ICustomerRepository>();
            var handler = new CreateCustomerCommandHandler(repositoryMock.Object);
            var command = new CreateCustomerCommand { Name = "Test Customer", Segment = "Premium" };

            // Act
            var result = await handler.Handle(command, CancellationToken.None);

            // Assert
            Assert.NotEqual(Guid.Empty, result);
            repositoryMock.Verify(r => r.CreateAsync(It.IsAny<Customer>()), Times.Once);
        }
    }
}
