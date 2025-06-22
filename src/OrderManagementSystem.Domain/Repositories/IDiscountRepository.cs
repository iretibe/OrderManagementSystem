namespace OrderManagementSystem.Domain.Repositories
{
    public interface IDiscountRepository
    {
        Task<decimal> ApplyDiscountAsync(Guid orderId, CancellationToken cancellationToken);
    }
}
