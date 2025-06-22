using MediatR;
using OrderManagementSystem.Domain.Entities;
using OrderManagementSystem.Domain.Repositories;

namespace OrderManagementSystem.Application.Commands.Handlers
{
    public class CreateCustomerCommandHandler : IRequestHandler<CreateCustomerCommand, Guid>
    {
        private readonly ICustomerRepository _repository;

        public CreateCustomerCommandHandler(ICustomerRepository repository)
        {
            _repository = repository;
        }

        public async Task<Guid> Handle(CreateCustomerCommand request, CancellationToken cancellationToken)
        {
            var customer = new Customer
            {
                Id = Guid.NewGuid(),
                Name = request.Name,
                Segment = request.Segment
            };

            await _repository.CreateAsync(customer);
            return customer.Id;
        }
    }
}
