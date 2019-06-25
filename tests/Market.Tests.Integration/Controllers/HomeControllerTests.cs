using System.Threading.Tasks;
using FluentAssertions;
using Market.Web;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Newtonsoft.Json;
using Xunit;

namespace Market.Tests.Integration.Controllers
{
    public class HomeControllerTests : IClassFixture<WebApplicationFactory<Startup>>
    {
        private readonly WebApplicationFactory<Startup> _factory;

        public HomeControllerTests(WebApplicationFactory<Startup> factory)
        {
            _factory = factory.WithWebHostBuilder(b => b.UseEnvironment("test"));
        }

        [Fact]
        public async Task get_api_endpoint_should_return_welcome_message()
        {
            // Arrange
            var httpClient = _factory.CreateClient();
            
            // Act
            var response = await httpClient.GetAsync("api");
            
            // Assert
            response.EnsureSuccessStatusCode(); // 200-299
            var message = await response.Content.ReadAsStringAsync();
            message.Should().Be("Welcome to Market API");
        }
        
        [Theory]
        [InlineData("/")]
        [InlineData("/privacy")]
        [InlineData("/products")]
        public async Task web_should_return_views(string endpoint)
        {
            var httpClient = _factory.CreateClient();

            var response = await httpClient.GetAsync(endpoint);

            response.EnsureSuccessStatusCode();
            response.Content.Headers.ContentType.ToString()
                .Should().Be("text/html; charset=utf-8");
        }
    }
}