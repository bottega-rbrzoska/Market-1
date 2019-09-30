using System;
using System.Threading.Tasks;
using Market.Application.Products.Commands;
using Market.Application.Products.Commands.Handlers;
using Market.Core.Entities;
using Market.Core.Repositories;
using NSubstitute;
using Shouldly;
using Xunit;

namespace Market.UnitTests.Handlers
{
    public class AddProductHandlerTests
    {
        private Task Act(AddProduct command) => _handler.HandleAsync(command);

        [Fact]
        public async Task given_valid_command_product_should_be_added()
        {
            // Arrange
            var command = new AddProduct(Guid.NewGuid(),
                "product", "products", "test", 100);

            // Act
            await Act(command);

            // Assert
            await _productsRepository.Received()
                .AddAsync(Arg.Is<Product>(p => p.Id == command.Id));
        }

        [Fact]
        public async Task given_command_with_invalid_name_product_should_not_be_added()
        {
            // Arrange
            var command = new AddProduct(Guid.NewGuid(),
                "invalid", "products", "test", 100);

            var exception = await Record.ExceptionAsync(() => Act(command));

            exception.ShouldNotBeNull();
            exception.ShouldBeOfType<ArgumentException>();
        }

        #region Arrange

        private readonly AddProductHandler _handler;
        private readonly IProductsRepository _productsRepository;

        public AddProductHandlerTests()
        {
            _productsRepository = Substitute.For<IProductsRepository>();
            _handler = new AddProductHandler(_productsRepository);
        }

        #endregion
    }
}