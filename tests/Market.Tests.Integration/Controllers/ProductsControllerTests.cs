using System.Collections.Generic;
using System.Threading.Tasks;
using FluentAssertions;
using Market.Application.Products.DTO;
using Market.Web;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Newtonsoft.Json;
using Xunit;

namespace Market.Tests.Integration.Controllers
{
    public class ProductsControllerTests : IClassFixture<WebApplicationFactory<Startup>>
    {
        private readonly WebApplicationFactory<Startup> _factory;

        public ProductsControllerTests(WebApplicationFactory<Startup> factory)
        {
            _factory = factory.WithWebHostBuilder(b => b.UseEnvironment("test"));
        }

        [Fact]
        public async Task get_products_should_return_empty_collection()
        {
            var httpClient = _factory.CreateClient();

            var response = await httpClient.GetAsync("api/products");

            response.EnsureSuccessStatusCode();
            var content = await response.Content.ReadAsStringAsync();
            var products = JsonConvert.DeserializeObject<IEnumerable<ProductDto>>(content);
            products.Should().BeEmpty();
        }
    }
}