using System;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Market.Application.Products.Commands;
using Market.Application.Products.DTO;
using Market.Web;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Newtonsoft.Json;
using Shouldly;
using Xunit;

namespace Market.IntegrationTests.Controllers
{
    public class ProductsControllerTests : IClassFixture<WebApplicationFactory<Startup>>
    {
        private readonly WebApplicationFactory<Startup> _factory;

        public ProductsControllerTests(WebApplicationFactory<Startup> factory)
        {
            _factory = factory.WithWebHostBuilder(b => b.UseEnvironment("test"));
        }
        
        [Fact]
        public async Task add_product_should_return_location_header()
        {
            var client = _factory.CreateClient();
            var command = new AddProduct(Guid.NewGuid(),
                "product", "products", "test", 100);

            var response = await client.PostAsJsonAsync("api/products", command);

            response.EnsureSuccessStatusCode();
            response.StatusCode.ShouldBe(HttpStatusCode.Created);
            response.Headers.Location.ToString().ShouldEndWith($"products/{command.Id}");
        }
        
        [Fact]
        public async Task test_scenario()
        {
            var client = _factory.CreateClient();
            var addProduct = new AddProduct(Guid.NewGuid(),
                "product", "products", "test", 100);

            var addProductResponse = await client.PostAsJsonAsync("api/products", addProduct);
            addProductResponse.EnsureSuccessStatusCode();

            var getProductResponse = await client.GetAsync(addProductResponse.Headers.Location);
            getProductResponse.EnsureSuccessStatusCode();
            var productJson = await getProductResponse.Content.ReadAsStringAsync();
            var productDto = JsonConvert.DeserializeObject<ProductDetailsDto>(productJson);
            
            productDto.ShouldNotBeNull();
            
            // Has to sign-in with 'admin' role
//            var deleteProductResponse = await client.DeleteAsync(addProductResponse.Headers.Location);
//            deleteProductResponse.EnsureSuccessStatusCode();
//            deleteProductResponse.StatusCode.ShouldBe(HttpStatusCode.NoContent);
        }
    }
}