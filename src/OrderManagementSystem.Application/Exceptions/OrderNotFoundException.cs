namespace OrderManagementSystem.Application.Exceptions
{
    public class OrderNotFoundException : AppException
    {
        public OrderNotFoundException(Guid id) : base($"Order with ID: `{id}` was not found.")
        {
        }
    }
}
