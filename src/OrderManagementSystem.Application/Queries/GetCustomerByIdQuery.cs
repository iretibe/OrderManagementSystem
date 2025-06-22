using MediatR;
using OrderManagementSystem.Domain.Entities;

namespace OrderManagementSystem.Application.Queries
{
    public class GetCustomerByIdQuery : IRequest<Customer?>
    {
        public Guid Id { get; set; }
    }
}
