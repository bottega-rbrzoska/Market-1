using System.Threading.Tasks;
using Market.Core.Repositories;

namespace Market.Application.Products.Commands.Handlers
{
    public class DeleteProductHandler : ICommandHandler<DeleteProduct>
    {
        private readonly IProductRepository _productRepository;

        public DeleteProductHandler(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }
        
        public async Task HandleAsync(DeleteProduct command)
        {
            await _productRepository.DeleteAsync(command.Id);
        }
    }
}