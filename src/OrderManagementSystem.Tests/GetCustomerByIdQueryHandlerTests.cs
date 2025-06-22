using Moq;
using OrderManagementSystem.Application.Queries;
using OrderManagementSystem.Application.Queries.Handlers;
using OrderManagementSystem.Domain.Entities;
using OrderManagementSystem.Domain.Repositories;

namespace OrderManagementSystem.Tests
{
    public class GetCustomerByIdQueryHandlerTests
    {
        [Fact]
        public async Task Handle_ExistingCustomerId_ShouldReturnCustomer()
        {
            // Arrange
            var customer = new Customer { Id = Guid.NewGuid(), Name = "Test", Segment = "Standard" };
            var repositoryMock = new Mock<ICustomerRepository>();
            repositoryMock.Setup(r => r.GetByIdAsync(customer.Id)).ReturnsAsync(customer);

            var handler = new GetCustomerByIdQueryHandler(repositoryMock.Object);
            var query = new GetCustomerByIdQuery { Id = customer.Id };

            // Act
            var result = await handler.Handle(query, CancellationToken.None);

            // Assert
            Assert.Equal(customer, result);
        }
    }
}
