using Moq;
using OrderManagementSystem.Application.Queries;
using OrderManagementSystem.Application.Queries.Handlers;
using OrderManagementSystem.Domain.Entities;
using OrderManagementSystem.Domain.Repositories;

namespace OrderManagementSystem.Tests
{
    public class GetAllCustomersQueryHandlerTests
    {
        [Fact]
        public async Task Handle_ShouldReturnAllCustomers()
        {
            // Arrange
            var customers = new List<Customer> { new Customer { Id = Guid.NewGuid(), Name = "A", Segment = "Basic" } };
            var repositoryMock = new Mock<ICustomerRepository>();
            repositoryMock.Setup(r => r.GetAllAsync()).ReturnsAsync(customers);

            var handler = new GetAllCustomersQueryHandler(repositoryMock.Object);
            var query = new GetAllCustomersQuery();

            // Act
            var result = await handler.Handle(query, CancellationToken.None);

            // Assert
            Assert.Single(result);
        }
    }
}
