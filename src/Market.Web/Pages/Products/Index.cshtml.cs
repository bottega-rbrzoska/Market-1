using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Market.Application;
using Market.Application.Products.Commands;
using Market.Application.Products.DTO;
using Market.Application.Products.Queries;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Market.Web.Pages.Products
{
    public class Index : PageModel
    {
        private readonly IDispatcher _dispatcher;

        public IEnumerable<ProductDto> Products { get; private set; }

        public Index(IDispatcher dispatcher)
        {
            _dispatcher = dispatcher;
        }

        public async Task OnGetAsync()
        {
            Products = await _dispatcher.QueryAsync(new GetProducts());
        }

        public async Task<ActionResult> OnPostDeleteAsync(Guid id)
        {
            await _dispatcher.SendAsync(new DeleteProduct(id));

            return RedirectToAction("./Index");
        }
    }
}