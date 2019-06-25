using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using FluentAssertions;
using Market.Application.Products.Commands;
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
        
        [Fact]
        public async Task add_product_should_succeed()
        {
            var httpClient = _factory.CreateClient();
            var command = new CreateProduct(Guid.Empty, "Huawei", "phones",
                "Huawei phone", 3500);
            var request = new StringContent(
                JsonConvert.SerializeObject(command), Encoding.UTF8,
                "application/json");

            var response = await httpClient.PostAsync("api/products", request);

            response.EnsureSuccessStatusCode();
            response.StatusCode.Should().Be(HttpStatusCode.Created);
            var productUrl = response.Headers.Location?.ToString();
            productUrl.Should().NotBeEmpty();

            var getResponse = await httpClient.GetAsync(productUrl);

            getResponse.EnsureSuccessStatusCode();
            var content = await getResponse.Content.ReadAsStringAsync();
            var product = JsonConvert.DeserializeObject<ProductDetailsDto>(content);
            product.Should().NotBeNull();
            product.Name.Should().Be(command.Name);
        }
    }
}