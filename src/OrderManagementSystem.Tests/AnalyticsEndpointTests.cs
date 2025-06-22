using FluentAssertions;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.VisualStudio.TestPlatform.TestHost;
using OrderManagementSystem.Domain.DTOs;
using System.Net;
using System.Net.Http.Json;

namespace OrderManagementSystem.Tests
{
    public class AnalyticsEndpointTests : IClassFixture<WebApplicationFactory<Program>>
    {
        private readonly HttpClient _client;

        public AnalyticsEndpointTests(WebApplicationFactory<Program> factory)
        {
            _client = factory.CreateClient();
        }

        [Fact]
        public async Task GetOrderAnalytics_ShouldReturnValidAnalytics()
        {
            // Act
            var response = await _client.GetAsync("/api/orders/analytics");

            // Assert
            response.StatusCode.Should().Be(HttpStatusCode.OK);

            var analytics = await response.Content.ReadFromJsonAsync<OrderAnalyticsDto>();
            analytics.Should().NotBeNull();
            analytics!.AverageOrderValue.Should().BeGreaterThanOrEqualTo(0);
            analytics!.AverageFulfillmentTime.Should().BeGreaterThan(TimeSpan.Zero);
        }
    }
}
