using System;
using System.Threading.Tasks;
using Market.Application;
using Market.Application.Products.DTO;
using Market.Application.Products.Queries;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Market.Web.Pages.Products
{
    public class Details : PageModel
    {
        private readonly IDispatcher _dispatcher;
        public ProductDetailsDto Product { get; private set; }

        public Details(IDispatcher dispatcher)
        {
            _dispatcher = dispatcher;
        }

        public async Task<ActionResult> OnGetAsync(Guid id)
        {
            Product = await _dispatcher.QueryAsync(new GetProduct
            {
                Id = id
            });
            if (Product is null)
            {
                return NotFound();
            }

            return Page();
        }
    }
}