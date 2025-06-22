using MediatR;

namespace OrderManagementSystem.Application.Commands
{
    public class CreateCustomerCommand : IRequest<Guid>
    {
        public string Name { get; set; } = string.Empty;
        public string Segment { get; set; } = string.Empty;
    }
}
