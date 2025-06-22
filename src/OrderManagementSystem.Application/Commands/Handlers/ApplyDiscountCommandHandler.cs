using MediatR;
using OrderManagementSystem.Application.Exceptions;
using OrderManagementSystem.Domain.Repositories;

namespace OrderManagementSystem.Application.Commands.Handlers
{
    public class ApplyDiscountCommandHandler : IRequestHandler<ApplyDiscountCommand, decimal>
    {
        private readonly IDiscountRepository _repository;

        public ApplyDiscountCommandHandler(IDiscountRepository repository)
        {
            _repository = repository;
        }

        public async Task<decimal> Handle(ApplyDiscountCommand request, CancellationToken cancellationToken)
        {
            var order = await _repository.ApplyDiscountAsync(request.OrderId, cancellationToken);

            if (order == 0) throw new OrderNotFoundException(request.OrderId);

            return order;
        }
    }
}
