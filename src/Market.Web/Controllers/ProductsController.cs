using System.Threading.Tasks;
using Market.Application;
using Market.Application.Products.Commands;
using Microsoft.AspNetCore.Mvc;

namespace Market.Web.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductsController : ControllerBase
    {
        private readonly ICommandHandler<CreateProduct> _handler;

        public ProductsController(ICommandHandler<CreateProduct>
            handler)
        {
            _handler = handler;
        }
        
        [HttpPost]
        public async Task<ActionResult> Post(CreateProduct command)
        {
            await _handler.HandleAsync(command);
            
            return Created($"api/products/{command.Id}", null);
        }
    }
}