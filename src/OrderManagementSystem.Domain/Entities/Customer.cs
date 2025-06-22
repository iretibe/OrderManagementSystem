namespace OrderManagementSystem.Domain.Entities
{
    public class Customer : BaseEntity
    {
        public string Name { get; set; } = default!;
        public string Segment { get; set; } = default!; // VIP, Loyal, etc.
        public ICollection<Order> Orders { get; set; } = new List<Order>();
    }
}
