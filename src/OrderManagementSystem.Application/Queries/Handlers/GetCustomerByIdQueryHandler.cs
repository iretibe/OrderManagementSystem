using MediatR;
using OrderManagementSystem.Application.Exceptions;
using OrderManagementSystem.Domain.Entities;
using OrderManagementSystem.Domain.Repositories;

namespace OrderManagementSystem.Application.Queries.Handlers
{
    public class GetCustomerByIdQueryHandler : IRequestHandler<GetCustomerByIdQuery, Customer?>
    {
        private readonly ICustomerRepository _repository;

        public GetCustomerByIdQueryHandler(ICustomerRepository repository)
        {
            _repository = repository;
        }

        public async Task<Customer?> Handle(GetCustomerByIdQuery request, CancellationToken cancellationToken)
        {
            var customer = await _repository.GetByIdAsync(request.Id);

            if (customer == null)
                throw new CustomerNotFoundException(request.Id);

            return customer;
        }
    }
}
