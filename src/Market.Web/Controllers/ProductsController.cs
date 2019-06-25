using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Market.Application;
using Market.Application.Products.Commands;
using Market.Application.Products.DTO;
using Market.Application.Products.Queries;
using Microsoft.AspNetCore.Authorization;
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

        [HttpGet("{id}")]
        public async Task<ActionResult<ProductDetailsDto>> Get([FromRoute] GetProduct query)
        {
            var product = await _dispatcher.QueryAsync(query);
            if (product is null)
            {
                return NotFound();
            }

            return product;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProductDto>>> Get([FromQuery] GetProducts query)
        {
            var products = await _dispatcher.QueryAsync(query);

            return Ok(products);
        }

        [HttpPost]
        public async Task<ActionResult> Post(CreateProduct command)
        {
            await _dispatcher.SendAsync(command);

            return Created($"api/products/{command.Id}", null);
        }

        [HttpDelete("{id}")]
        [Authorize(AuthenticationSchemes = "Bearer", Policy = "admin")]
        public async Task<ActionResult> Delete(Guid id)
        {
            await _dispatcher.SendAsync(new DeleteProduct(id));

            return NoContent();
        }
    }
}