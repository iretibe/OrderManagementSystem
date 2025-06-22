using MediatR;

namespace OrderManagementSystem.Application.Commands
{
    public class DeleteCustomerCommand : IRequest
    {
        public Guid Id { get; set; }
    }
}
