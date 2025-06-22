using MediatR;
using OrderManagementSystem.Domain.Entities;

namespace OrderManagementSystem.Application.Queries
{
    public class GetAllCustomersQuery : IRequest<List<Customer>> { }
}
