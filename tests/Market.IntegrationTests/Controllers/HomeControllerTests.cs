using System.Threading.Tasks;
using Market.Web;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Shouldly;
using Xunit;

namespace Market.IntegrationTests.Controllers
{
    public class HomeControllerTests : IClassFixture<WebApplicationFactory<Startup>>
    {
        private readonly WebApplicationFactory<Startup> _factory;
        
        public HomeControllerTests(WebApplicationFactory<Startup> factory)
        {
            _factory = factory.WithWebHostBuilder(b => b.UseEnvironment("test"));
        }

        [Fact]
        public async Task get_app_endpoint_should_return_app_name()
        {
            var client = _factory.CreateClient();

            var response = await client.GetAsync("app");

            response.EnsureSuccessStatusCode();
            var appName = await response.Content.ReadAsStringAsync();
            
            appName.ShouldBe("Market [test]");
        }
    }
}