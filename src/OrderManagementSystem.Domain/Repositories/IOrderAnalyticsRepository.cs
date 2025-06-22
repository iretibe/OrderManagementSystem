namespace OrderManagementSystem.Domain.Repositories
{
    public interface IOrderAnalyticsRepository
    {
        decimal GetAverageOrderValue();
        TimeSpan GetAverageFulfillmentTime();
    }
}
