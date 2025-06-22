namespace OrderManagementSystem.Domain.DTOs
{
    public class OrderAnalyticsDto
    {
        public decimal AverageOrderValue { get; set; }
        public TimeSpan AverageFulfillmentTime { get; set; }
    }
}
