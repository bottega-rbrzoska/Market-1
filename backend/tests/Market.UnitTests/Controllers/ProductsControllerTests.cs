using System;
using System.Threading.Tasks;
using Market.Application;
using Market.Application.Products.DTO;
using Market.Application.Products.Queries;
using Market.Web.Controllers;
using Microsoft.AspNetCore.Mvc;
using NSubstitute;
using Shouldly;
using Xunit;

namespace Market.UnitTests.Controllers
{
    public class ProductsControllerTests
    {
        private ProductsController _controller;
        private IDispatcher _dispatcher;

        public ProductsControllerTests()
        {
            _dispatcher = Substitute.For<IDispatcher>();
            _controller = new ProductsController(_dispatcher);
        }

        [Fact]
        public async Task given_invalid_id_product_should_not_be_returned()
        {
            var productId = Guid.NewGuid();
            var result = await _controller.Get(productId);
            await _dispatcher.Received().QueryAsync(Arg.Is<GetProduct>(
                q => q.Id == productId));
            result.Value.ShouldBeNull();
        }
        
        [Fact]
        public async Task given_valid_id_product_should_be_returned()
        {
            var productId = Guid.NewGuid();
            _dispatcher.QueryAsync(Arg.Is<GetProduct>(
                    q => q.Id == productId))
                .Returns(new ProductDetailsDto
                {
                    Id = productId
                });
            
            var result = await _controller.Get(productId);
            await _dispatcher.Received().QueryAsync(Arg.Is<GetProduct>(
                q => q.Id == productId));
            
            var okResult = result.Result as OkObjectResult;
            okResult.ShouldNotBeNull();

            var dto = okResult.Value as ProductDetailsDto;
            dto.ShouldNotBeNull();
            dto.Id.ShouldBe(productId);
        }
    }
}