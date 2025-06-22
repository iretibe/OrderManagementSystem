namespace OrderManagementSystem.Application.Exceptions
{
    public class CustomerNotFoundException : AppException
    {
        public CustomerNotFoundException(Guid id) : base($"Customer with ID: `{id}` was not found.")
        {
        }
    }
}
