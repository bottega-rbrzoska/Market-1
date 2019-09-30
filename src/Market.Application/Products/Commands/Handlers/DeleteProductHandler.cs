using System.Threading.Tasks;
using Market.Core.Repositories;

namespace Market.Application.Products.Commands.Handlers
{
    public class DeleteProductHandler : ICommandHandler<DeleteProduct>
    {
        private readonly IProductsRepository _productsRepository;

        public DeleteProductHandler(IProductsRepository productsRepository)
        {
            _productsRepository = productsRepository;
        }
        
        public async Task HandleAsync(DeleteProduct command)
        {
            await _productsRepository.DeleteAsync(command.Id);
        }
    }
}