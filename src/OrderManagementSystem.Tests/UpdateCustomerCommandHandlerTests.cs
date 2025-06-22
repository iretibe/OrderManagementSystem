using Moq;
using OrderManagementSystem.Application.Commands;
using OrderManagementSystem.Application.Commands.Handlers;
using OrderManagementSystem.Domain.Entities;
using OrderManagementSystem.Domain.Repositories;

namespace OrderManagementSystem.Tests
{
    public class UpdateCustomerCommandHandlerTests
    {
        [Fact]
        public async Task Handle_ExistingCustomer_ShouldUpdateCustomer()
        {
            // Arrange
            var customer = new Customer { Id = Guid.NewGuid(), Name = "Old Name", Segment = "Standard" };
            var repositoryMock = new Mock<ICustomerRepository>();
            repositoryMock.Setup(r => r.GetByIdAsync(customer.Id)).ReturnsAsync(customer);

            var handler = new UpdateCustomerCommandHandler(repositoryMock.Object);
            var command = new UpdateCustomerCommand { Id = customer.Id, Name = "New Name", Segment = "Premium" };

            // Act
            await handler.Handle(command, CancellationToken.None);

            // Assert
            Assert.Equal("New Name", customer.Name);
            Assert.Equal("Premium", customer.Segment);
            repositoryMock.Verify(r => r.UpdateAsync(customer), Times.Once);
        }
    }
}
