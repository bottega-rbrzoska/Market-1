using System;
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
        private readonly IDispatcher _dispatcher;

        public ProductsController(IDispatcher dispatcher)
        {
            _dispatcher = dispatcher;
        }

        [HttpPost]
        public async Task<ActionResult> Post(CreateProduct command)
        {
            await _dispatcher.SendAsync(command);

            return Created($"api/products/{command.Id}", null);
        }
        
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(Guid id)
        {
            await _dispatcher.SendAsync(new DeleteProduct(id));

            return NoContent();
        }
    }
}