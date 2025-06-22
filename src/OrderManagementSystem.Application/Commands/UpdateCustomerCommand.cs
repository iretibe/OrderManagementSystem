using MediatR;

namespace OrderManagementSystem.Application.Commands
{
    public class UpdateCustomerCommand : IRequest
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Segment { get; set; } = string.Empty;
    }
}
