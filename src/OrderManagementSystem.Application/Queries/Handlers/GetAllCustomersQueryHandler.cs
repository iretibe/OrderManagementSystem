using MediatR;
using OrderManagementSystem.Domain.Entities;
using OrderManagementSystem.Domain.Repositories;

namespace OrderManagementSystem.Application.Queries.Handlers
{
    public class GetAllCustomersQueryHandler : IRequestHandler<GetAllCustomersQuery, List<Customer>>
    {
        private readonly ICustomerRepository _repository;

        public GetAllCustomersQueryHandler(ICustomerRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<Customer>> Handle(GetAllCustomersQuery request, CancellationToken cancellationToken)
        {
            return await _repository.GetAllAsync();
        }
    }
}
