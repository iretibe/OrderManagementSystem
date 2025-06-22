using Moq;
using OrderManagementSystem.Application.Commands;
using OrderManagementSystem.Application.Commands.Handlers;
using OrderManagementSystem.Domain.Repositories;

namespace OrderManagementSystem.Tests
{
    public class DeleteCustomerCommandHandlerTests
    {
        [Fact]
        public async Task Handle_ValidId_ShouldDeleteCustomer()
        {
            // Arrange
            var repositoryMock = new Mock<ICustomerRepository>();
            var handler = new DeleteCustomerCommandHandler(repositoryMock.Object);
            var command = new DeleteCustomerCommand { Id = Guid.NewGuid() };

            // Act
            await handler.Handle(command, CancellationToken.None);

            // Assert
            repositoryMock.Verify(r => r.DeleteAsync(command.Id), Times.Once);
        }
    }
}
