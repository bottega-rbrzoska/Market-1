using System.Threading.Tasks;
using Market.Core.Entities;
using Market.Core.Repositories;

namespace Market.Application.Products.Commands.Handlers
{
    //SRP
    public class CreateProductHandler : ICommandHandler<CreateProduct>
    {
        private readonly IProductRepository _productRepository;

        public CreateProductHandler(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task HandleAsync(CreateProduct command)
        {
            var product = new Product(command.Id, command.Name, command.Category, command.Description, command.Price);
            await _productRepository.AddAsync(product);
            // eventDispatcher.PublishAsync(new ProductCreated(product))
        }
    }
}