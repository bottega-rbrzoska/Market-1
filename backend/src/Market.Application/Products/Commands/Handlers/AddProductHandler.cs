using System;
using System.Threading.Tasks;
using Market.Core.Entities;
using Market.Core.Repositories;

namespace Market.Application.Products.Commands.Handlers
{
    //SRP
    public class AddProductHandler : ICommandHandler<AddProduct>
    {
        private readonly IProductsRepository _productsRepository;

        public AddProductHandler(IProductsRepository productsRepository)
        {
            _productsRepository = productsRepository;
        }

        public async Task HandleAsync(AddProduct command)
        {
            if (command.Name == "invalid")
            {
                throw new ArgumentException("Invalid product name.", nameof(command.Name));
            }
            
            var product = new Product(command.Id, command.Name, command.Category, command.Description, command.Price);
            await _productsRepository.AddAsync(product);
            // eventDispatcher.PublishAsync(new ProductCreated(product))
        }
    }
}